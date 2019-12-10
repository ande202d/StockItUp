using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Filter
{
    class SupplierFilter:IComparer<Supplier>
    {
        public int Compare(Supplier x, Supplier y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.CompareTo(y);
        }
    }
}
