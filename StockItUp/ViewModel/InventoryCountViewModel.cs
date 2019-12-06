using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Connections;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class InventoryCountViewModel: INotifyPropertyChanged
    {
        #region Instance fields

        private Catalog<Location> _locationCatalog;
        private Catalog<Product> _productCatalog;
        private Catalog<StoreProduct> _storeProductCatalog;
        private Catalog<InventoryCountProduct> _inventoryCountProductCatalog;
        private Catalog<InventoryCount> _inventoryCountCatalog;
        private Location _selectedLocation;
        private InventoryCountHistory _selectedInventoryCountHistory;

        //this one is only so we dont "rerun" the code and make all the values 0 again
        private List<InventoryCountPage> _listForProducts; 

        #endregion

        #region Constructor

        public InventoryCountViewModel()
        {
            _locationCatalog = Catalog<Location>.Instance;
            _productCatalog = Catalog<Product>.Instance;
            _storeProductCatalog = Catalog<StoreProduct>.Instance;
            _inventoryCountProductCatalog = Catalog<InventoryCountProduct>.Instance;
            _inventoryCountCatalog = Catalog<InventoryCount>.Instance;
            CreateInventoryCountCommand = new RelayCommand(CreateInventoryCountMethod);
        }

        #endregion

        #region Commands

        public ICommand CreateInventoryCountCommand { get; set; }
        

        #endregion

        #region Properties

        public ObservableCollection<Location> LocationCatalog
        {
            get
            {
                ObservableCollection<Location> collection = new ObservableCollection<Location>(_locationCatalog.GetList);
                return collection;
            }
        }

        public ObservableCollection<Product> ProductCatalog
        {
            get
            {
                ObservableCollection<Product> collection = new ObservableCollection<Product>(_productCatalog.GetList);
                return collection;
            }
        }

        public ObservableCollection<StoreProduct> StoreProductCatalog
        {
            get
            {
                ObservableCollection<StoreProduct> collection = new ObservableCollection<StoreProduct>(_storeProductCatalog.GetList);
                return collection;
            }
        }

        public List<InventoryCountPage> ListForProducts
        {
            get
            {
                List<InventoryCountPage> nlist = new List<InventoryCountPage>();
                foreach (var sp in StoreProductCatalog)
                {
                    foreach (var product in ProductCatalog)
                    {
                        if (sp.Product == product.Id)
                        {
                            nlist.Add(new InventoryCountPage(product));
                        }
                    }
                }

                _listForProducts = nlist;
                return nlist;
            }
        }


        public Location SelectedLocation
        {
            get { return _selectedLocation; }
            set { _selectedLocation = value; }
        }

        //to get the list of all previous made inventoryCounts
        public ObservableCollection<InventoryCountHistory> InventoryCountHistoriesCatalog
        {
            get
            {
                ObservableCollection<InventoryCountHistory> collection = 
                    new ObservableCollection<InventoryCountHistory>(Catalog<InventoryCountHistory>.Instance.GetList);
                return collection;
            }
        }

        //To select a different old inventoryCount to show data from
        public InventoryCountHistory SelectedInventoryCountHistory
        {
            get
            {
                if (_selectedInventoryCountHistory == null) return new InventoryCountHistory();
                return _selectedInventoryCountHistory;
            }
            set { _selectedInventoryCountHistory = value; OnPropertyChanged();
                OnPropertyChanged(nameof(InventoryCountHistoriesCatalogData));
            }
        }

        //The list of the data from the old inventoryCount that is selected
        public ObservableCollection<InventoryCountHistoryData> InventoryCountHistoriesCatalogData
        {
            get
            {
                List<InventoryCountHistoryData> listToReturn = new List<InventoryCountHistoryData>();

                foreach (var i in Catalog<InventoryCountHistoryData>.Instance.GetList)
                {
                    if (i.InventoryCountHistory == SelectedInventoryCountHistory.Id)
                    {
                        listToReturn.Add(i);
                    }
                }

                ObservableCollection<InventoryCountHistoryData> collection = 
                    new ObservableCollection<InventoryCountHistoryData>(listToReturn);
                return collection;
            }
        }

        #endregion

        #region Methods

        public async void CreateInventoryCountMethod()
        {
            //we make sure that we have selected a location to count
            if (SelectedLocation != null)
            {
                //now we make a new inventoryCount from that location and we then put it in the database FINT
                InventoryCount ic = new InventoryCount(SelectedLocation);
                await _inventoryCountCatalog.Create(ic);

                //now we take that IC out again, to make sure we are working with the right id's FINT
                InventoryCount ic2 = Catalog<InventoryCount>.Instance.GetList.FindLast(x =>
                    x.Location == SelectedLocation.Id &&
                    x.DateCounted >= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)));

                #region Test Area
                ////Hvis den crasher her, så sig det lige, ved godt hvad der går galt, ved bare ikke hvorfor :/
                //int q1 = ic2.Id;
                //int q2 = ic2.Location;
                //Location q3 = ic2.MyLocation;
                //DateTime q4 = ic2.DateCounted;

                #endregion

                //here we freeze that inventoryCount in our history class FINT
                InventoryCountHistory ich = new InventoryCountHistory(ic2);
                await Catalog<InventoryCountHistory>.Instance.Create(ich);

                //We go though all the data provided by the user and checking its counted to something above 0
                //this bool is for checking that data is inserted relative to the inventoryCount
                bool gotData = false;
                foreach (var i in _listForProducts)
                {
                    int totalAmount = (i.BoxAmount * i.Product.AmountPerBox) + i.Amount;
                    if (totalAmount > 0)
                    {
                        //here we then create a "data" row for that specific product and inventoryCount
                        //and store it in the database
                        InventoryCountProduct icp = new InventoryCountProduct(ic2.Id, i.Product.Id, totalAmount);
                        await Catalog<InventoryCountProduct>.Instance.Create(icp);

                        //we then make a frozen copy of that inventoryCount "data" and throw it in the history database
                        InventoryCountHistoryData ichd = new InventoryCountHistoryData(ich.Id, i.Product.Name, icp.Amount, i.Product.AmountPerBox);
                        ichd.Id = Catalog<InventoryCountProduct>.Instance.GetList.
                            Find(x=> x.InventoryCount==ic2.Id && x.Product == icp.Product).Id;
                        //InventoryCountHistoryData ichd = new InventoryCountHistoryData(ic2.Id, i.Product.Name, i.Amount);
                        await Catalog<InventoryCountHistoryData>.Instance.Create(ichd);

                        gotData = true;
                    }
                }

                //if no inventoryCountProduct / inventoryCountHistoryData is provided, both the inventoryCount and the record of it is deleted
                if (!gotData)
                {
                    await Catalog<InventoryCount>.Instance.Delete(ic2.Id);
                    await Catalog<InventoryCountHistory>.Instance.Delete(ich.Id);
                }
               OnPropertyChanged(nameof(InventoryCountHistoriesCatalog));
            }
        }


        #endregion


        #region On Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
       
    }
}
