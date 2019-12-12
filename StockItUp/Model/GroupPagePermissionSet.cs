using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class GroupPagePermissionSet
    {
        private string _name;
        private bool _state;

        public GroupPagePermissionSet(string name, bool state)
        {
            _name = name;
            _state = state;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
