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
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class ProductViewModel:INotifyPropertyChanged
    {
        #region Instance fields

        private Catalog<Product> _productCatalog;
        private  Catalog<Supplier> _supplierCatalog;
        private Product _selectedProduct = new Product(default(string),default(int));
        private Supplier _selectedSupplier = new Supplier(default(string),"www.");
        private Supplier _selectedSupplierForCreationOfProduct;

        #endregion

        #region Constructor

        public ProductViewModel()
        {
            _productCatalog = Catalog<Product>.Instance;
            _supplierCatalog = Catalog<Supplier>.Instance;
            CreateProductCommand = new RelayCommand(CreateProductMethod);
            CreateSupplierCommand = new RelayCommand(CreateSupplierMethod);
            DeleteProductCommand = new RelayCommand(DeleteProductMethod);
            DeleteSupplierCommand = new RelayCommand(DeleteSupplierMethod);
            UpdateProductCommand = new RelayCommand(UpdateProductMethod);
            UpdateSupplierCommand = new RelayCommand(UpdateSupplierMethod);

        }

        #region Commands
        public ICommand CreateProductCommand { get; set; }
        public ICommand CreateSupplierCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand UpdateSupplierCommand { get; set; }



        #endregion

        #endregion

        #region Porperties

        //returns an observable of products collection based on what the catalog pulls from the database
        public ObservableCollection<Product> ProductCatalog
        {
            get
            {
                ObservableCollection<Product> collection = new ObservableCollection<Product>(_productCatalog.ReadAll().Result);
                

                return collection;
            }
        }

        //returns an observable of supplies collection based on what the catalog pulls from the database
        public ObservableCollection<Supplier> SupplierCatalog
        {
            get
            {
                return new ObservableCollection<Supplier>(_supplierCatalog.ReadAll().Result);
            }
        }

        public Product SelectedProduct
        {
            get { return _selectedProduct;}
            set { _selectedProduct = value; OnPropertyChanged();}
        }

        public Supplier SelectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value;OnPropertyChanged(); }
        }
        public Supplier SelectedSupplierForCreationOfProduct
        {
            get { return _selectedSupplierForCreationOfProduct; }
            set {
                _selectedSupplierForCreationOfProduct = value;
                if (SelectedProduct!=null)
                {
                    SelectedProduct.Supplier = _selectedSupplierForCreationOfProduct.Id;
                }
                OnPropertyChanged();
            }
        }


        #endregion

        #region Methods

        private void CreateProductMethod()
        {
            if (SelectedProduct!=null)
            {
                    {
                        _productCatalog.Create(SelectedProduct);
                        OnPropertyChanged(nameof(ProductCatalog));
                    }       
            }
            
            
        }

        private void CreateSupplierMethod()
        {
                _supplierCatalog.Create(SelectedSupplier);
                OnPropertyChanged(nameof(SupplierCatalog));
        }

        private void DeleteProductMethod()
        {
            if (SelectedProduct != null)
            {
                _productCatalog.Delete(SelectedProduct.Id);
                OnPropertyChanged(nameof(ProductCatalog));
            }

        }

        private void DeleteSupplierMethod()
        {
            if (SelectedSupplier!=null)
            {
                _supplierCatalog.Delete(SelectedSupplier.Id);
            OnPropertyChanged(nameof(SupplierCatalog));
            }
        }

        private void UpdateProductMethod()
        {
            if (SelectedProduct!=null && SelectedProduct.Name!="" && SelectedProduct.AmountPerBox!=-1)
            {

                    _productCatalog.Update(SelectedProduct.Id,SelectedProduct);
                    OnPropertyChanged(nameof(ProductCatalog));
            }
            

        }

        private void UpdateSupplierMethod()
        {

            _supplierCatalog.Update(SelectedSupplier.Id, SelectedSupplier);
            OnPropertyChanged(nameof(SupplierCatalog));
            OnPropertyChanged(nameof(ProductCatalog));

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
