using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class StoragePageProduct
    {
        private Product _Product;
        private int _total;
        private int _wanted;
        private int _missing;

        public StoragePageProduct(Product product, int total, int wanted, int missing)
        {
            _Product = product;
            _total = total;
            _wanted = wanted;
            _missing = missing;
        }


        public string Name
        {
            get { return _Product.Name; }
        }

        public Product MyProduct
        {
            get { return _Product; }
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
    }
}
