﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Filter
{
    class OrderPageFilterBySupplier:IComparer<OrderPage>
    {
        public int Compare(OrderPage x, OrderPage y)
        {
            if (x == null || y == null || x.Supplier==null || y.Supplier==null)
            {
                return 0;
            }

            return x.Supplier.CompareTo(y.Supplier);
        }
    }
}
