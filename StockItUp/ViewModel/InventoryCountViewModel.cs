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

        public List<InventoryCountPage> listForProducts
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

        #endregion

        #region Methods

        public async void CreateInventoryCountMethod()
        {
            //we make sure that we have selected a location to count
            if (SelectedLocation != null)
            {
                //now we make a new inventoryCount from that location and we then put it in the database
                InventoryCount ic = new InventoryCount(SelectedLocation);
                await _inventoryCountCatalog.Create(ic);

                //now we take that IC out again, to make sure we are working with the right id's
                InventoryCount ic2 = Catalog<InventoryCount>.Instance.GetList.FindLast(x =>
                    x.Location == SelectedLocation.Id &&
                    x.DateCounted >= DateTime.Now.Subtract(TimeSpan.FromSeconds(10)));

                #region Test Area
                //Hvis den crasher her, så sig det lige, ved godt hvad der går galt, ved bare ikke hvorfor :/
                int q1 = ic2.Id;
                int q2 = ic2.Location;
                Location q3 = ic2.MyLocation;
                DateTime q4 = ic2.DateCounted;

                #endregion

                //here we freeze that inventoryCount in our history class
                InventoryCountHistory ich = new InventoryCountHistory(ic2);
                await Catalog<InventoryCountHistory>.Instance.Create(ich);

                //We go though all the data provided by the user and checking its counted to something above 0
                foreach (var i in _listForProducts)
                {
                    if (i.Amount > 0)
                    {
                        //here we then create a "data" row for that specific product and inventoryCount
                        //and store it in the database
                        InventoryCountProduct icp = new InventoryCountProduct(ic2.Id, i.Product.Id, i.Amount);
                        await Catalog<InventoryCountProduct>.Instance.Create(icp);

                        //we then make a frozen copy of that inventoryCount "data" and throw it in the history database
                        InventoryCountHistoryData ichd = new InventoryCountHistoryData(ich.Id, i.Product.Name, icp.Amount);
                        await Catalog<InventoryCountHistoryData>.Instance.Create(ichd);
                    }
                }
               
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
