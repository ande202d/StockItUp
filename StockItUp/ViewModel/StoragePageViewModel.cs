using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
                List<StoragePageProduct> listToReturn = new List<StoragePageProduct>();
                
                #region Magic *puff*

                foreach (var s in Catalog<Store>.Instance.GetList)
                {
                    if (s.Id == 1)
                    {
                        //List<InventoryCount> newestIcOnEachLocation = GetNewestIc();
                        //List<int> newestIcId = new List<int>();
                        //foreach (var ic in newestIcOnEachLocation)
                        //{
                        //    newestIcId.Add(ic.Id);
                        //}

                        foreach (var sp in Catalog<StoreProduct>.Instance.GetList)
                        {
                            //List<InventoryCount> newestIcOnEachLocation = GetNewestIc(sp.Id);
                            List<int> newestIcId = getNewstIcIds(sp.Id);
                            int p;
                            int t = 0;
                            int w;
                            int m;

                            if (sp.Store == s.Id)
                            {
                                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                {
                                    if (newestIcId.Contains(icp.InventoryCount) && icp.Product == sp.Product)
                                    {
                                        t += icp.Amount;
                                    }
                                }

                                p = Catalog<Product>.Instance.Read(sp.Product).Result.Id;
                                w = sp.Amount;
                                m = w - t;
                                listToReturn.Add(new StoragePageProduct(p,t,w,m));
                            }
                        }
                    }
                }

                #endregion

                ObservableCollection<StoragePageProduct> collection= new ObservableCollection<StoragePageProduct>();
                if (Filter=="")
                {
                    collection = new ObservableCollection<StoragePageProduct>(listToReturn);
                }
                else
                {
                    foreach (var v in listToReturn)
                    {
                        if (v.MyProduct.Name.ToLower().Contains(Filter))
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

                //List<InventoryCount> ics = GetNewestIc();
                //List<int> newestIcId = new List<int>();
                //foreach (var ic in ics)
                //{
                //    newestIcId.Add(ic.Id);
                //}
                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                {
                    List<InventoryCount> ics = GetNewestIc(icp.Product);
                    List<int> newestIcId = getNewstIcIds(icp.Product);
                    if (SelectedProduct!=null)
                    {
                        if (newestIcId.Contains(icp.InventoryCount) && icp.Product == SelectedProduct.ProductId)
                            {
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
                    StoreProduct tempStoreProduct = new StoreProduct(storeId, id, SelectedProduct.Wanted);
                    int key = Catalog<StoreProduct>.Instance.GetList.Find(x =>
                        x.Store == storeId && x.Product == id).Id;
                    await Catalog<StoreProduct>.Instance.Update(key, tempStoreProduct);
               
                OnPropertyChanged(nameof(ProductCatalog));
            }
            
        }


        //returns a list of inventoryCounts, only one on each location,
        //and it is only the newest one from that location
        //furthermore, it is only locations that is located in the current store
        //and it is only saved if the inventoryCount acturaly counted any instances of that specific product
        //that way you dont have to count all products at all time in every location
        private List<InventoryCount> GetNewestIc(int productId)
        {
            List<InventoryCount> newestIcOnEachLocation = new List<InventoryCount>();
            foreach (var s in Catalog<Store>.Instance.GetList)
            {
                if (s.Id == 1)
                {
                    foreach (var l in Catalog<Location>.Instance.GetList)
                    {
                        if (l.Store == s.Id)
                        {
                            InventoryCount icDummy = new InventoryCount();
                            foreach (var ic in Catalog<InventoryCount>.Instance.GetList)
                            {
                                //if (ic.Location == l.Id && ic.DateCounted > icDummy.DateCounted)
                                //    icDummy = ic;
                                if (ic.Location == l.Id && ic.DateCounted > icDummy.DateCounted)
                                {
                                    foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                    {
                                        if (icp.Product == productId && icp.InventoryCount == ic.Id)
                                        {
                                            icDummy = ic;
                                        }
                                    }
                                }
                            }

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

        private List<int> getNewstIcIds(int productId)
        {
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
