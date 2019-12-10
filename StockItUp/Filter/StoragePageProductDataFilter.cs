using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class StoragePageProductDataFilter:IComparer<StoragePageProductData>
    {
        public int Compare(StoragePageProductData x, StoragePageProductData y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.LocationName.CompareTo(y.LocationName);
        }
    }
}
