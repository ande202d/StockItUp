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
            if (SelectedLocation != null)
            {
                InventoryCount ic = new InventoryCount(SelectedLocation);
                await _inventoryCountCatalog.Create(ic);

                InventoryCount ic2 = Catalog<InventoryCount>.Instance.GetList.FindLast(x =>
                    x.Location == SelectedLocation.Id &&
                    x.DateCounted > DateTime.Now.Subtract(TimeSpan.FromSeconds(5)));

                foreach (var i in _listForProducts)
                {
                    if (i.Amount > 0)
                    {
                        InventoryCountProduct icp = new InventoryCountProduct(ic2.Id, i.Product.Id, i.Amount);
                        await Catalog<InventoryCountProduct>.Instance.Create(icp);
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
