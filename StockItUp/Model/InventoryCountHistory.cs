﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountHistory
    {
        private int _id;
        private string _location;
        private DateTime _countDate;

        //This needs to be changed to InventoryCountProduct, witch is our middeltabel,
        //where we both have the InventoryCount "raw data" and the products that got counted
        //we then need to go though the catalog that contains these InventoryCountProduct and find
        //all the products that got the foreign key from the InventoryCount

        //This data is then stored in InventoryCountHistoryData where the Foreign Key is the one from
        //this class, and then we got the product name and amount counted
        public InventoryCountHistory(InventoryCount i)
        {
            _id = i.Id;
            _location = i.Location.Name;
            _countDate = i.DateTime;
        }

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Location1
        {
            get { return _location; }
            set { _location = value; }
        }

        public DateTime CountDate
        {
            get { return _countDate; }
            set { _countDate = value; }
        } 
        #endregion

    }
}