﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderHistoryData
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private int _orderHistoryId;
        private string _product;
        private string _supplier;
        private int _missingAmount;
        private int _amountPerBox;
        private int _recommendedAmount;
        private int _amountOrdered;
        private string _email;
        #endregion

        #region Constructors
        public OrderHistoryData(int orderHistoryId, string product, string supplier, string email, int missingAmount, int amountPerBox, int recommendedAmount, int amountOrdered)
        {
            _id = _idCounter;
            _idCounter++;
            _orderHistoryId = orderHistoryId;
            _product = product;

            if (supplier == null) _supplier = "";
            else _supplier = supplier;

            _email = email;
            _missingAmount = missingAmount;
            _amountPerBox = amountPerBox;
            _recommendedAmount = recommendedAmount;
            _amountOrdered = amountOrdered;
        }

        public OrderHistoryData()
        {
        } 
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int MissingAmount
        {
            get { return _missingAmount; }
            set { _missingAmount = value; }
        }

        public int AmountPerBox
        {
            get { return _amountPerBox; }
            set { _amountPerBox = value; }
        }

        public int RecommendedAmount
        {
            get { return _recommendedAmount; }
            set { _recommendedAmount = value; }
        }

        public int AmountOrdered
        {
            get { return _amountOrdered; }
            set { _amountOrdered = value; }
        }

        public int OrderHistory
        {
            get { return _orderHistoryId; }
            set { _orderHistoryId = value; }
        }

        public string Supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion

    }
}
