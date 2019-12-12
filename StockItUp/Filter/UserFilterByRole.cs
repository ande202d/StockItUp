using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class UserFilterByRole:IComparer<User>
    {
        public int Compare(User x, User y)
        {
            if (x == null || y == null)
            {
                return 0;
            }

            return x.GroupName.CompareTo(y.GroupName);
        }
    }
}
