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
        private Product _Product;
        private int _total;
        private string _totalv2;
        private int _wanted;
        private int _missing;

        public StoragePageProduct(int product, int total, int wanted, int missing, string totalv2)
        {
            //_Product = product;
            ProductId = product;
            _total = total;
            _wanted = wanted;
            _missing = missing;
            _totalv2 = totalv2;
        }


        //public string Name
        //{
        //    get
        //    {
        //        if (ProductId!=0)
        //        {
        //            return MyProduct.Name;
        //        }

        //        return "";
        //    }
        //}

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
    }
}
