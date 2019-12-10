using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class StoragePageProductFilter:IComparer<StoragePageProduct>
    {
        public int Compare(StoragePageProduct x, StoragePageProduct y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.MyProduct.CompareTo(y.MyProduct);
        }
    }
}
