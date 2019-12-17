using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountHistory
    {
        #region Instance fields

        private int _id;
        private string _location;
        private DateTime _countDate;
        #endregion


        #region Constructors
        public InventoryCountHistory(InventoryCount i)
        {
            _id = i.Id;
            _location = i.MyLocation.Name;
            _countDate = i.DateCounted;
        }

        public InventoryCountHistory()
        {
        } 
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string DateFormatted
        {
            get { return CountDate.ToString("dd / MM / yyyy HH:mm"); }
        }

        public DateTime CountDate
        {
            get { return _countDate; }
            set { _countDate = value; }
        }
        #endregion

    }
}
