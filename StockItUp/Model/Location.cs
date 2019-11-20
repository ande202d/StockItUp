using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class Location
    {
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private Store _myStore;

        #region Constructor
        public Location(Store store, string name)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
            _myStore = store;
        }

        public Location(string name)
        {
            _id = _idCounter;
            _idCounter++;
            Store = null;
            _name = name;
        }

        public Location()
        {
        }

        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Store MyStore
        {
            get { return _myStore; }
            set { _myStore = value; }
        }

        public int? Store { get; set; }
        #endregion

    }
}
