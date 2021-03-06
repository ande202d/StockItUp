﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Persistency;

namespace StockItUp.Model
{
    public class InventoryCount
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private DateTime _dateTime;
        private Location _location; 
        #endregion

        #region Constructor
        public InventoryCount(Location location)
        {
            _id = _idCounter;
            Id = _idCounter;
            _idCounter++;
            _dateTime = DateTime.Now;
            _location = location;
            Location = location.Id;

            MyLocationName = location.Name;
        }

        public InventoryCount()
        {
        }

        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime DateCounted
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        public int Location { get; set; }
        public Location MyLocation
        {
            get { return Catalog<Location>.Instance.Read(Location).Result; }
            set { _location = value; }
        }

        public string MyLocationName { get; set; }

        #endregion
    }
}
