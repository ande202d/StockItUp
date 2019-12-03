﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderHistory
    {
        private int _id;
        private DateTime _orderedDate;

        //same comment as the one in inventoryCountHistory
        public OrderHistory()
        {
            
        }

        public OrderHistory(Order o)
        {
            _id = o.Id;
            _orderedDate = o.Time;
        }

        #region properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime OrderedDate
        {
            get { return _orderedDate; }
            set { _orderedDate = value; }
        } 
        #endregion

    }
}
