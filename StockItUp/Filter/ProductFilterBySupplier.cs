using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class ProductFilterBySupplier:IComparer<Product>
    {
        public int Compare(Product x, Product y)
        {
            if (x == null || y == null || x.MySupplier==null || y.MySupplier==null)
            {
                return 0;
            }

            return x.MySupplier.CompareTo(y.MySupplier);
        }
    }
}
