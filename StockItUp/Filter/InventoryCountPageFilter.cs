using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class InventoryCountPageFilter:IComparer<InventoryCountPage>
    {
        public int Compare(InventoryCountPage x, InventoryCountPage y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Product.CompareTo(y.Product);
        }
    }
}
