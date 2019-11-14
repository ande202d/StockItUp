using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCount
    {
        private int _id;
        private static int _idCounter = 1;
        private DateTime _dateTime;
        private Dictionary<Product, int> _counting;
        private Location _location;

        #region Constructor
        public InventoryCount(Location location, Dictionary<Product, int> dictionary)
        {
            _id = _idCounter;
            _idCounter++;
            _dateTime = DateTime.Now;
            _location = location;
            _counting = dictionary;
        }
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public Dictionary<Product, int> GetDictionary
        {
            get { return _counting; }
            set { _counting = value; }
        }
        public List<Product> ListProducts
        {
            get { return _counting.Keys.ToList(); }
        }
        public List<int> ListAmounts
        {
            get { return _counting.Values.ToList(); }
        }
        #endregion
    }
}
