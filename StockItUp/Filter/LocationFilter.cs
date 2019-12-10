using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class LocationFilter:IComparer<Location>
    {
        public int Compare(Location x, Location y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.Name.CompareTo(y.Name);
        }
    }
}
