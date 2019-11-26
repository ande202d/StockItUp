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
        private StoragePageProduct _selectedProduct;

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
                List<StoragePageProduct> listToReturn = new List<StoragePageProduct>();
                
                #region Magic *puff*

                foreach (var s in Catalog<Store>.Instance.GetList)
                {
                    if (s.Id == 1)
                    {
                        List<InventoryCount> newestIcOnEachLocation = GetNewestIc();
                        List<int> newestIcId = new List<int>();
                        foreach (var ic in newestIcOnEachLocation)
                        {
                            newestIcId.Add(ic.Id);
                        }

                        foreach (var sp in Catalog<StoreProduct>.Instance.GetList)
                        {
                            Product p;
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

                                p = Catalog<Product>.Instance.Read(sp.Product).Result;
                                w = sp.Amount;
                                m = w - t;
                                listToReturn.Add(new StoragePageProduct(p,t,w,m));
                            }
                        }
                    }
                }

                #endregion
                
                ObservableCollection<StoragePageProduct> collection = new ObservableCollection<StoragePageProduct>(listToReturn);
                return collection;
            }
        }

        public ObservableCollection<StoragePageProductData> ProductCatalogData
        {
            get
            {
                List<StoragePageProductData> listToReturn = new List<StoragePageProductData>();

                List<InventoryCount> ics = GetNewestIc();
                List<int> newestIcId = new List<int>();
                foreach (var ic in ics)
                {
                    newestIcId.Add(ic.Id);
                }
                foreach (var icp in Catalog<InventoryCountProduct>.Instance.GetList)
                {
                    if (newestIcId.Contains(icp.InventoryCount) && icp.Product == SelectedProduct.MyProduct.Id)
                    {
                        InventoryCount ic = ics.Find(x => x.Id == icp.InventoryCount);

                        listToReturn.Add(new StoragePageProductData(ic.MyLocation.Name, ic.DateCounted, icp.Amount));
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
            set { _selectedProduct = value; OnPropertyChanged(); }
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

        //This shit returns a list of inventoryCounts, only one on each location,
        //and it is only the newest one from that location
        //furthermore, it is only locations that is located in the current store
        private List<InventoryCount> GetNewestIc()
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
                                if (ic.Location == l.Id && ic.DateCounted > icDummy.DateCounted)
                                    icDummy = ic;

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
