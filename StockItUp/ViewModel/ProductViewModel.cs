using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class ProductViewModel
    {
        #region Instance fields

        private static Catalog<Product> _productCatalog;
        private static Catalog<Supplier> _supplierCatalog;


        #endregion

        #region Constructor

        ProductViewModel()
        {
            _productCatalog = Catalog<Product>.Instance;
            _supplierCatalog = Catalog<Supplier>.Instance;
            
        }

        #endregion

        #region Porperties

        //returns an observable of products collection based on what the catalog pulls from the database
        public ObservableCollection<Product> ProductCatalog
        {
            get
            {
                return new ObservableCollection<Product>(_productCatalog.ReadAll().Result);
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

        #endregion

    }
}
