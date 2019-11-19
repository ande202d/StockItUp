using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class Store
    {
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private string _address;

        #region Constructor
        public Store(string name, string adress)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
            _address = adress;
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

        public string Adress
        {
            get { return _address; }
            set { _address = value; }
        }
        #endregion
    }
}
