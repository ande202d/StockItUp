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
                string n; //the name of the product
                int t = 0; //the latest amount counted 

                //JEG MANGLER AT LIGGE DE FORSKELLIGE LOKATIONERS OPTÆLLINGER SAMMEN.
                //LIGE NU TAGER DEN BARE DEN SIDSTE NYE OG BRUGER DEN, DEN KIGGER IKKE ENGANG PÅ LOKATIONEN
                
                //Gå inventoryCount igennem i forhold til location
                //og bagefter check om det er den sidste nye på den placering
                //noget i den stil

                int w; //The amount wanted from the stores perspective of the product
                int m; //the missing amount (w - t)



                List<StoreProduct> list2 = Catalog<StoreProduct>.Instance.GetList;
                List<StoragePageProduct> listToReturn = new List<StoragePageProduct>();

                #region Magic
                foreach (StoreProduct sp in list2)
                {
                    //Does it match the store
                    if (sp.Store == Catalog<Store>.Instance.GetList[0].Id)
                    {
                        //Getting the right name from the product
                        n = "test";
                        foreach (Product p in Catalog<Product>.Instance.GetList)
                        {
                            //Making sure that the products ID matches the ID from the stores "ProductList"
                            if (p.Id == sp.Product)
                            {
                                n = p.Name;
                                t = -1;
                                //Now we go all the data though, if the data got the newest id that we found before
                                //and it also is the right productID, we simple plus our total amount with it.
                                InventoryCount icSaved = new InventoryCount();
                                foreach (InventoryCountProduct icp in Catalog<InventoryCountProduct>.Instance.GetList)
                                {
                                    if (icp.Product == p.Id)
                                    {
                                        //now we are sure that the data is about the right product
                                        //now we need to take that InventoryCountId and save it, and the next
                                        //time we find another match, we check witch InventoryCountId that is the newest
                                        InventoryCount icToCheck = Catalog<InventoryCount>.Instance
                                            .Read(icp.InventoryCount).Result;
                                        if (icSaved.DateCounted < icToCheck.DateCounted)
                                        {
                                            icSaved = icToCheck;
                                            t = icp.Amount;
                                        }
                                    }
                                }
                            }
                        }
                        w = sp.Amount;
                        if (t == -1) m = -1;
                        else
                        {
                            m = w - t;
                        }
                        listToReturn.Add(new StoragePageProduct(n, t, w, m));
                    }
                }
                #endregion

                #region We can break out of a for loop, but we cant from a foreach loop

                //for (int storeIndex = 0; storeIndex < Catalog<Store>.Instance.GetList.Count; storeIndex++)
                //{
                //    for (int storeProductIndex = 0; 
                //        storeProductIndex < Catalog<StoreProduct>.Instance.GetList.Count; 
                //        storeProductIndex++)
                //    {
                //        if (Catalog<StoreProduct>.Instance.GetList[storeProductIndex].Store ==
                //            Catalog<Store>.Instance.GetList[0].Id)
                //        {
                //            //now we are in the first occured condition where the ID matches the store
                //            StoreProduct sp = Catalog<StoreProduct>.Instance.GetList[storeProductIndex];
                //            for (int inventoryCountIndex = 0; 
                //                inventoryCountIndex < Catalog<InventoryCount>.Instance.GetList.Count; 
                //                inventoryCountIndex++)
                //            {
                //                //if (Catalog<InventoryCount>.Instance.GetList[inventoryCountIndex].Id == )
                //            }
                //        }
                //    }
                //} 
                #endregion

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
