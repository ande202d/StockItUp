using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Calls;
using Windows.Devices.Lights;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Connections;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class StoragePageViewModel : INotifyPropertyChanged
    {
        #region Instance fields

        private Catalog<Location> _locationCatalog;
        private Catalog<Store> _storeCatalog;
        private Location _selectedLocation = new Location(Catalog<Store>.Instance.Read(1).Result, default(string));
        private Store _selectedLocationStore;
        private StoragePageProduct _selectedProduct;
        private string _filter="";

        #endregion

        #region Constructor

        public StoragePageViewModel()
        {
            _locationCatalog = Catalog<Location>.Instance;
            _storeCatalog = Catalog<Store>.Instance;
            CreateLocationCommand = new RelayCommand(CreateLocationMethod);
            DeleteLocationCommand = new RelayCommand(DeleteLocationMethod);
            UpdateLocationCommand = new RelayCommand(UpdateLocationMethod);
            ChangeWantedAmountCommand = new RelayCommand(ChangeWantedAmountMethod);
            //Product tempProduct = new Product();
            //SelectedProduct = new StoragePageProduct(tempProduct.Id, default(int), default(int), default(int));

        }

        #endregion

        #region Commands
        public ICommand CreateLocationCommand { get; set; }
        public ICommand DeleteLocationCommand { get; set; }
        public ICommand UpdateLocationCommand { get; set; }
        public ICommand ChangeWantedAmountCommand { get; set; }


        #endregion



        #region Porperties

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; OnPropertyChanged(nameof(ProductCatalog)); }
        }
        //returns an observable of products collection based on what the catalog pulls from the database
        public ObservableCollection<Location> LocationCatalog
        {
            get
            {
                ObservableCollection<Location> collection = new ObservableCollection<Location>(_locationCatalog.GetList);


                return collection;
            }
        }

        public ObservableCollection<Store> StoreCatalog
        {
            get
            {
                ObservableCollection<Store> collection = new ObservableCollection<Store>(_storeCatalog.GetList);

                return collection;
            }
        }

        public ObservableCollection<StoragePageProduct> ProductCatalog
        {
            get
            {
                //first we create a list that in the end is converted to a observable collection
                List<StoragePageProduct> listToReturn = new List<StoragePageProduct>();
                
                //Here magic happens... just kidding, notes inside
                #region Magic *puff*

                //first we go though each store in the database, and make sure we are working with the right store
                foreach (var s in Catalog<Store>.Instance.GetList)
                {
                    if (s.Id == 1)
                    {
                        //then we go though all the wanted products and if the store wants that product, we go further
                        foreach (var sp in Catalog<StoreProduct>.Instance.GetList)
                        {
                            //here we get a list of all the id's from the inventoryCounts that matches this specific product
                            List<int> newestIcId = getNewstIcIds(sp.Product);

                            #region Test Area
                            int p;
                            int t = 0;
                            int w;
                            int m;
                            string t2 = "";
                            #endregion

                            //if the product is on the wanted list:
                            if (sp.Store == s.Id)
                            {
                                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                {
                                    //Here we check all the data from all IC's
                                    //If one of the data, is from the right inventoryCount (the newest for that product in that location)
                                    //and of course the data also has to be about the right product
                                    //then we take the counted amount from that data-row and add it to the total amount for that product
                                    if (newestIcId.Contains(icp.InventoryCount) && icp.Product == sp.Product)
                                    {
                                        t += icp.Amount;
                                    }
                                }

                                //here we are getting ready to create our "dummy" class for showing the right information, getting name, and other data
                                Product pro = Catalog<Product>.Instance.Read(sp.Product).Result;
                                p = pro.Id;
                                w = sp.Amount;
                                m = w - t;
                                if (m < 0) m = 0;
                                //(int) Math.Ceiling((double) m / p.AmountPerBox);
                                int placeholder1 = (int) Math.Floor((double) t / pro.AmountPerBox);
                                int placeholder2 = t - (placeholder1 * pro.AmountPerBox);
                                t2 = $"{placeholder1} kasser og {placeholder2} løse";
                                listToReturn.Add(new StoragePageProduct(p,t,w,m, t2));
                            }
                        }
                    }
                }

                #endregion

                //then we make the observable collection...
                ObservableCollection<StoragePageProduct> collection= new ObservableCollection<StoragePageProduct>();

                //here we have added a filter, if it is empty, it simply returns the collection, but if not....
                if (Filter=="")
                {
                    collection = new ObservableCollection<StoragePageProduct>(listToReturn);
                }
                else
                {
                    foreach (var v in listToReturn)
                    {
                        //if not, we go though the name of each product, and if the name contains the string from the filter, we add it to the visible list
                        if (v.MyProduct.Name.ToLower().Contains(Filter.ToLower()))
                        {
                            collection.Add(v);
                        }
                    }
                }
                 
                return collection;
            }
        }

        public ObservableCollection<StoragePageProductData> ProductCatalogData
        {
            get
            {
                List<StoragePageProductData> listToReturn = new List<StoragePageProductData>();
                
                //here we go though all IC's data rows
                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                {
                    //we then use our method to get a list of all the newest data from each location specific to that product
                    List<InventoryCount> ics = GetNewestIc(icp.Product);
                    //our other method, that returns the same as above, but only their id's
                    List<int> newestIcId = getNewstIcIds(icp.Product);
                    if (SelectedProduct!=null)
                    {
                        if (newestIcId.Contains(icp.InventoryCount) && icp.Product == SelectedProduct.ProductId)
                            {
                                //if we got a mach from the method and this specific data-row, and also it is the actual product that is selected
                                //we add that data-row to be shown
                                InventoryCount ic = ics.Find(x => x.Id == icp.InventoryCount);
                                listToReturn.Add(new StoragePageProductData(ic.MyLocation.Name, ic.DateCounted, icp.Amount));
                            }
                    }
                    
                }
                
                ObservableCollection<StoragePageProductData> collection = new ObservableCollection<StoragePageProductData>(listToReturn);
                return collection;
            }
        }

        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set { _selectedLocation = value; OnPropertyChanged(); }
        }

        public Store SelectedLocationStore
        {
            get { return _selectedLocationStore; }
            set
            {
                _selectedLocationStore = value;
                if (SelectedLocation!=null)
                {
                    SelectedLocation.Store = SelectedLocationStore.Id;
                }
                OnPropertyChanged();
            }
        }

        public StoragePageProduct SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); OnPropertyChanged(nameof(ProductCatalogData)); }
        }

        public string ChangeWantedAmountResponse { get; set; }

        #endregion

        #region Methods

        private async void CreateLocationMethod()
        {
           SelectedLocation.Store = SelectedLocation.MyStore.Id;
           await _locationCatalog.Create(SelectedLocation);
           OnPropertyChanged(nameof(LocationCatalog));
        }

        private async void DeleteLocationMethod()
        {
            if(SelectedLocation != null)
            { 
                await _locationCatalog.Delete(SelectedLocation.Id);
                OnPropertyChanged(nameof(LocationCatalog));
            }
        }


        private async void UpdateLocationMethod()
        {
            await _locationCatalog.Update(SelectedLocation.Id, SelectedLocation);
            OnPropertyChanged(nameof(LocationCatalog));
        }

        private async void ChangeWantedAmountMethod()
        {
            if (SelectedProduct!=null)
            {
                int storeId = 1;
                int id = SelectedProduct.ProductId;
                int wanted = SelectedProduct.Wanted;
                StoreProduct tempStoreProduct = new StoreProduct(storeId, id, wanted);
                //    int key = Catalog<StoreProduct>.Instance.GetList.Find(x =>
                //        x.Store == storeId && x.Product == id).Id;
                //    await Catalog<StoreProduct>.Instance.Update(key, tempStoreProduct); 
                // update doesnt work because of a badrequest(400), i cant fix i so we decided to just delete the old one and create a new one with the values given
                int key = Catalog<StoreProduct>.Instance.GetList.Find(x =>
                            x.Store == storeId && x.Product == id).Id;
                await Catalog<StoreProduct>.Instance.Delete(key);
                if (wanted>=1)
                {
                    await Catalog<StoreProduct>.Instance.Create(tempStoreProduct);
                    ChangeWantedAmountResponse = $"det ønskede antal for {SelectedProduct.MyProduct.Name} er blevet ændret";
                }
                if (wanted<=0)
                {
                    ChangeWantedAmountResponse = $"Da du har ønsket {wanted} er produkt blevet fjernet";
                }

                

                OnPropertyChanged(nameof(ChangeWantedAmountResponse));
                OnPropertyChanged(nameof(ProductCatalog));
            }
            
        }

        public static List<InventoryCount> GetNewestIc(int productId)
        {
            //the purpose is tho get the newest inventoryCount from each location, but only if the specific product was actual counted
            List<InventoryCount> newestIcOnEachLocation = new List<InventoryCount>();
            foreach (var s in Catalog<Store>.Instance.GetList)
            {
                //we go though all the stores, and make sure we got the right store
                if (s.Id == 1)
                {
                    foreach (var l in Catalog<Location>.Instance.GetList)
                    {
                        //we then go though all locations that is located in that store
                        if (l.Store == s.Id)
                        {
                            //here we make a dummy inventoryCount, this is to make sure that we only get the newest
                            InventoryCount icDummy = new InventoryCount();
                            foreach (var ic in Catalog<InventoryCount>.Instance.GetList)
                            {
                                //in all the inventoryCounts(IC's), if ones location, is the one we are checking, and also the date it was counted
                                //is newer than the dummies, we come further in (dummy date when created is day 1, in year 1)
                                if (ic.Location == l.Id && ic.DateCounted > icDummy.DateCounted)
                                {
                                    foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                    {
                                        //here we then check if the specific IC-data matches the product, and also it matches the inventoryCounts that got approved
                                        if (icp.Product == productId && icp.InventoryCount == ic.Id)
                                        {
                                            icDummy = ic;
                                        }
                                    }
                                }
                            }

                            //in the case that no inventoryCount is made, we don't want it to add the dummy to the list.
                            //that's why we check that the dummy we are adding, have been counted after day 2 since the beginning of time
                            if (icDummy.DateCounted > (DateTime.MinValue.Add(TimeSpan.FromDays(2))))
                            {
                                newestIcOnEachLocation.Add(icDummy);
                            }
                        }
                    }
                }
            }

            return newestIcOnEachLocation;
        }

        public static List<int> getNewstIcIds(int productId)
        {
            //this method just uses the GetNewestIc -method, and takes all the id's in a list and return it
            List<int> listToReturn = new List<int>();
            foreach (var ic in GetNewestIc(productId))
            {
                listToReturn.Add(ic.Id);
            }

            return listToReturn;
        }

        #endregion

        #region OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
