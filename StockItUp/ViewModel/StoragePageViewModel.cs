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
        private Location _selectedLocation;
        private Store _selectedLocationStore;

        #endregion

        #region Constructor

        public StoragePageViewModel()
        {
            _locationCatalog = Catalog<Location>.Instance;
            _storeCatalog = Catalog<Store>.Instance;
            CreateLocationCommand = new RelayCommand(CreateLocationMethod);
            DeleteLocationCommand = new RelayCommand(DeleteLocationMethod);
            UpdateLocationCommand = new RelayCommand(UpdateLocationMethod);

        }

        #endregion

        #region Commands
        public ICommand CreateLocationCommand { get; set; }
        public ICommand DeleteLocationCommand { get; set; }
        public ICommand UpdateLocationCommand { get; set; }



        #endregion

  

        #region Porperties

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
                string n;
                int t = 0;
                int w;
                int m;
                //List<Product> list1 = Catalog<Product>.Instance.ReadAll().Result;
                List<StoreProduct> list2 = Catalog<StoreProduct>.Instance.GetList;
                list2 = Catalog<StoreProduct>.Instance.GetList;

                List<StoragePageProduct> listToReturn = new List<StoragePageProduct>();

                //Storeproducts har "0" i både product og store id, når de bliver læst fra databasen
                //Dette er grundet den clustered key
                foreach (StoreProduct sp in list2)
                {
                    //Does it match the store
                    if (sp.Store == Catalog<Store>.Instance.GetList[0].Id)
                    {
                        //Getting the right name from the product
                        n = "test";
                        foreach (Product p in Catalog<Product>.Instance.GetList)
                        {
                            if (p.Id == sp.Product)
                            {
                                n = p.Name;

                                //Location loc = Catalog<Location>.Instance.ReadAll().Result[1];
                                //InventoryCount testIc = new InventoryCount(loc);
                                //Catalog<InventoryCount>.Instance.Create(testIc);

                                //List<InventoryCount> hahaha = Catalog<InventoryCount>.Instance.ReadAll().Result;
                                //int icid = hahaha[0].Id;
                                //Catalog<InventoryCountProduct>.Instance.Create(new InventoryCountProduct(icid,1, 20));
                                
                                foreach (InventoryCount ic in Catalog<InventoryCount>.Instance.GetList)
                                {
                                    InventoryCount icc = new InventoryCount();
                                    if (icc == null) icc = ic;
                                    else if (ic.DateTime > icc.DateTime) icc = ic;

                                    foreach (InventoryCountProduct icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                    {
                                        if (icp.InventoryCount == icc.Id || icp.Product == p.Id)
                                        {
                                            t += icp.Amount;
                                        }
                                    }
                                }

                            }

                        }
                        w = sp.Amount;
                        m = w - t;
                        listToReturn.Add(new StoragePageProduct(n,t,w,m));
                    }
                }
                ObservableCollection<StoragePageProduct> collection = new ObservableCollection<StoragePageProduct>(listToReturn);
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

        #endregion

        #region Methods

        private void CreateLocationMethod()
        {
            //Store s1 = Catalog<Store>.Instance.Read(0).Result;
            //string s = SelectedLocation.Name;
           //_locationCatalog.Create(SelectedLocation);
           //OnPropertyChanged(nameof(LocationCatalog));
        }

        private void DeleteLocationMethod()
        {
            if(SelectedLocation != null)
            { 
                _locationCatalog.Delete(SelectedLocation.Id);
                OnPropertyChanged(nameof(LocationCatalog));
            }
        }


        private void UpdateLocationMethod()
        {
            _locationCatalog.Update(SelectedLocation.Id, SelectedLocation);
            OnPropertyChanged(nameof(LocationCatalog));
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
