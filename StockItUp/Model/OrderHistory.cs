﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderHistory
    {
        #region Instance fields
        private int _id;
        private DateTime _orderedDate;
        private int _storeId;
        #endregion

        #region Constructors
        public OrderHistory()
        {

        }

        public OrderHistory(Order o, int storeId)
        {
            _id = o.Id;
            _orderedDate = o.OrderDate;
            _storeId = storeId;
        } 
        #endregion

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

        public string DateFormatted
        {
            get { return OrderedDate.ToString("dd / MM / yyyy HH:mm"); }
        } 

        public int StoreId
        {
            get { return _storeId;}
            set { _storeId = value; }
        }
        #endregion

    }
}
