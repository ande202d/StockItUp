using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class StoragePageProduct
    {
        private string _name;
        private int _total;
        private int _wanted;
        private int _missing;

        public StoragePageProduct(string name, int total, int wanted, int missing)
        {
            _name = name;
            _total = total;
            _wanted = wanted;
            _missing = missing;
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public int Wanted
        {
            get { return _wanted; }
            set { _wanted = value; }
        }

        public int Missing
        {
            get { return _missing; }
            set { _missing = value; }
        }
    }
}
