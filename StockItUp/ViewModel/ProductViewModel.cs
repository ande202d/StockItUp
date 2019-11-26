using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Data;
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
        private Supplier _selectedSupplier = new Supplier(default(string),"www.");
        private Supplier _selectedSupplierForCreationOfProduct;
        private string _filter = "";

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
            MakeDefaultProduct();
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

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; OnPropertyChanged(nameof(ProductCatalog));}
        }

        //returns an ObservableCollection of products collection based on what the catalog pulls from the database
        public ObservableCollection<Product> ProductCatalog
        {
            get
            {
                //ObservableCollection<Product> collection = new ObservableCollection<Product>(_productCatalog.ReadAll().Result);
                ObservableCollection<Product> collection = new ObservableCollection<Product>();
                if (Filter == "")
                {
                    collection = new ObservableCollection<Product>(_productCatalog.GetList);
                }
                else
                {
                    foreach (var v in _productCatalog.GetList)
                    {
                        if (v.Name.ToLower().Contains(Filter))
                        {
                            collection.Add(v);
                        }
                    }
                }
                return collection;
            }
        }

        //returns an ObservableCollection of supplies collection based on what the catalog pulls from the database
        public ObservableCollection<Supplier> SupplierCatalog
        {
            get
            {
                return new ObservableCollection<Supplier>(_supplierCatalog.GetList);
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

        //made a property for a combobox, 
        public Supplier SelectedSupplierForCreationOfProduct
        {
            get { return _selectedSupplierForCreationOfProduct; }
            set {
                _selectedSupplierForCreationOfProduct = value;
                if (SelectedProduct!=null)
                {
                    if (SelectedSupplierForCreationOfProduct==null)
                    {
                        SelectedProduct.Supplier = null;
                    }
                    else
                    {
                        SelectedProduct.Supplier = _selectedSupplierForCreationOfProduct.Id;
                    }
                }
                OnPropertyChanged();
            }
        }


        #endregion

        #region Methods

        //adds a product with the values given in the view to the database using the catalog
        private async void CreateProductMethod()
        {
            if (SelectedProduct!=null && SelectedProduct.Name != "" && SelectedProduct.AmountPerBox != 0)
            {
                if (SelectedSupplierForCreationOfProduct != null)
                {
                   SelectedProduct.Supplier = SelectedSupplierForCreationOfProduct.Id; 
                }
                await _productCatalog.Create(SelectedProduct);
                OnPropertyChanged(nameof(ProductCatalog));
            }
            SelectedSupplierForCreationOfProduct = null;
        }

        //adds a supplier with the values given in the view to the database using the catalog
        private async void CreateSupplierMethod()
        {
                await _supplierCatalog.Create(SelectedSupplier);
                OnPropertyChanged(nameof(SupplierCatalog));
        }

        //delete the selected product from the database
        private async void DeleteProductMethod()
        {
            if (SelectedProduct != null)
            {
                await _productCatalog.Delete(SelectedProduct.Id);
                OnPropertyChanged(nameof(ProductCatalog));
                MakeDefaultProduct();
            }
            SelectedSupplierForCreationOfProduct = null;

        }

        //delete the selected supplier from the database
        private async void DeleteSupplierMethod()
        {
            if (SelectedSupplier!=null)
            {
                //foreach (var product in ProductCatalog)
                //{
                //    if (product.Supplier==SelectedSupplier.Id)
                //    {
                //        await _productCatalog.Delete(product.Id);
                //    }
                //}
                await _supplierCatalog.Delete(SelectedSupplier.Id);
                OnPropertyChanged(nameof(SupplierCatalog));
                OnPropertyChanged(nameof(ProductCatalog));
            }
        }

        //update a product in the database with new values from the view
        private async void UpdateProductMethod()
        {
            if (SelectedProduct!=null)
            {
                if (SelectedSupplierForCreationOfProduct==null)
                {
                    SelectedProduct.Supplier = null;
                }
                    await _productCatalog.Update(SelectedProduct.Id,SelectedProduct);
                    OnPropertyChanged(nameof(ProductCatalog));
                    MakeDefaultProduct();                    
            }

            SelectedSupplierForCreationOfProduct = null;
        }

        //update a supplier in the database with new values from the view
        private async void UpdateSupplierMethod()
        {
            await _supplierCatalog.Update(SelectedSupplier.Id, SelectedSupplier);
            OnPropertyChanged(nameof(SupplierCatalog));
            OnPropertyChanged(nameof(ProductCatalog));
        }

        //changes the SelectedProduct to default values
        private void MakeDefaultProduct()
        {
            SelectedProduct = new Product(default(string), default(int));
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
