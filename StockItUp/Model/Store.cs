using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class Store
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private string _address; 
        #endregion

        #region Constructor
        public Store(string name, string address)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
            _address = address;
        }

        public Store()
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

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        #endregion
    }
}
