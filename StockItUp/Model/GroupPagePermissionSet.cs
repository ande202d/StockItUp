using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class GroupPagePermissionSet
    {
        #region Instance fields

        private string _name;
        private bool _state;

        #endregion

        #region Constructor
        public GroupPagePermissionSet(string name, bool state)
        {
            _name = name;
            _state = state;
        }
        #endregion

        #region Properties
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
        #endregion
    }
}
