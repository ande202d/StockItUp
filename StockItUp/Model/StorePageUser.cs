using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class StorePageUser
    {
        private string _name;
        private bool _worksAtStore;
        private int _userId;

        public StorePageUser(string name, bool worksAtStore, int userId)
        {
            _name = name;
            _worksAtStore = worksAtStore;
            _userId = userId;
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool WorksAtStore
        {
            get { return _worksAtStore; }
            set { _worksAtStore = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
    }
}
