using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Persistency;

namespace StockItUp.Model
{
    public class StoragePageProduct
    {
        #region Instance fields
        private Product _Product;
        private int _total;
        private string _totalv2;
        private int _wanted;
        private int _missing;
        #endregion

        #region Constructors
        public StoragePageProduct(int product, int total, int wanted, int missing, string totalv2)
        {
            ProductId = product;
            _total = total;
            _wanted = wanted;
            _missing = missing;
            _totalv2 = totalv2;
        }
        #endregion

        #region Properties
        public int ProductId { get; }

        public Product MyProduct
        {
            get { return Catalog<Product>.Instance.Read(ProductId).Result; ; }
            set { _Product = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public int Wanted
        {
            get { return _wanted; }
            set { _wanted = value; }
        }

        public int Missing
        {
            get { return _missing; }
            set { _missing = value; }
        }

        public string Totalv2
        {
            get { return _totalv2; }
            set { _totalv2 = value; }
        } 
        #endregion
    }
}
