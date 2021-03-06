﻿using System;
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
using StockItUp.Connections;
using StockItUp.Filter;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class ProductViewModel:BaseViewModel
    {
        #region Instance fields

        private Catalog<Product> _productCatalog;
        private  Catalog<Supplier> _supplierCatalog;
        private Product _selectedProduct;
        private Supplier _selectedSupplier = new Supplier(default(string),"");
        private Supplier _selectedSupplierForCreationOfProduct;
        private string _filter = "";
        private string _selectedSort;

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
            AddToWantedListCommand = new RelayCommand(AddToWantedListMethod);
            MakeDefaultProduct();
        }

        #region Commands
        public ICommand CreateProductCommand { get; set; }
        public ICommand CreateSupplierCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand DeleteSupplierCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand UpdateSupplierCommand { get; set; }
        public ICommand AddToWantedListCommand { get; set; }


        #endregion

        #endregion

        #region Properties

        public Controller Controller
        {
            get { return Controller.Instance; }
        }

        public PermissionGroup Permission
        {
            get { return Catalog<PermissionGroup>.Instance.Read(Controller.Instance.GetUser.GroupId).Result; }
        }

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
                List<Product> pl = _productCatalog.GetList;
                pl.Sort(new ProductFilter());
                ObservableCollection<Product> collection = new ObservableCollection<Product>();

                if (SelectedSort == "Leverandør")
                {
                    pl.Sort(new ProductFilterBySupplier());
                }

                if (SelectedSort == "Vare navn")
                {
                    pl.Sort(new ProductFilter());
                }
                if (SelectedSort == "Vare ID")
                {
                    pl.Sort(new ProductFilterByProductId());
                }
                if (Filter == "")
                {
                    collection = new ObservableCollection<Product>(pl);
                }
                else
                {
                    foreach (var v in pl)
                    {
                        if (v.Name.ToLower().Contains(Filter.ToLower()))
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
                List<Supplier> sl = _supplierCatalog.GetList;
                sl.Sort();
                return new ObservableCollection<Supplier>(sl);
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

        public int WantedAmount { get; set; }

        public string AddToWantedResponse { get; set; }

        public List<String> SortingCollection { get { return  new List<string>(){"Vare ID", "Vare navn", "Leverandør"};} }

        public string SelectedSort
        {
            get { return _selectedSort; }
            set { _selectedSort = value;OnPropertyChanged();OnPropertyChanged(nameof(ProductCatalog)); }
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
                await Catalog<StoreProduct>.Instance.ReadAll();
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

        private async void AddToWantedListMethod()
        {
            int storeId = Controller.Instance.StoreId;
            bool isOnList = false;
            foreach (var storeProduct in Catalog<StoreProduct>.Instance.GetList)
            {
                if (storeProduct.Product==SelectedProduct.Id&&storeProduct.Store==storeId)
                {
                    isOnList = true;
                    AddToWantedResponse = $"{SelectedProduct.Name} er allerede på listen"; 
                }
            }

            if (!isOnList&&WantedAmount>0)
            {
                int productId = SelectedProduct.Id;
                int wantedAmount = WantedAmount;
                StoreProduct spToAdd = new StoreProduct(storeId,productId,wantedAmount);
                await Catalog<StoreProduct>.Instance.Create(spToAdd);
                AddToWantedResponse = $"{SelectedProduct.Name} er nu tilføjet til listen"; 
            }

            if (WantedAmount<=0)
            {
                AddToWantedResponse = "det ønskede antal skal være over 0";
            }
            OnPropertyChanged(nameof(AddToWantedResponse));
        }

        //changes the SelectedProduct to default values
        private void MakeDefaultProduct()
        {
            SelectedProduct = new Product(default(string), default(int));
        }

        #endregion


        
    }
}
