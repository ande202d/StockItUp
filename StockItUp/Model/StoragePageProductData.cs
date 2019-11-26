using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class StoragePageProductData
    {
        private string _locationName;
        private DateTime _lastCounted;
        private int _amount;

        public StoragePageProductData(string locationName, DateTime lastCounted, int amount)
        {
            _locationName = locationName;
            _lastCounted = lastCounted;
            _amount = amount;
        }

        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        public DateTime LastCounted
        {
            get { return _lastCounted; }
            set { _lastCounted = value; }
        }

        public string DateFormatted
        {
            get { return LastCounted.ToString("dd / MM / yyyy"); }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
