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
        private Product _selectedProduct;
        private Supplier _selectedSupplier;

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



        #endregion

        #region Methods

        private void CreateProductMethod()
        {
            //_productCatalog.Create(new Product())
        }

        private void CreateSupplierMethod()
        {
            //_productSupplier.Create(new Supplier())
        }

        private void DeleteProductMethod()
        {
            _productCatalog.Delete(SelectedProduct.Id);
        }

        private void DeleteSupplierMethod()
        {
            _supplierCatalog.Delete(SelectedSupplier.Id);
        }

        private void UpdateProductMethod()
        {
            //_productCatalog.update()
        }

        private void UpdateSupplierMethod()
        {
            //_supplierCatalog.update()
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
