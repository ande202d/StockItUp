using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderHistory
    {
        private int _id;
        private DateTime _orderedDate;
        private int _storeId;

        //same comment as the one in inventoryCountHistory
        public OrderHistory()
        {
            
        }

        public OrderHistory(Order o)
        {
            _id = o.Id;
            _orderedDate = o.OrderDate;
        }

        #region properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime OrderedDate
        {
            get { return _orderedDate; }
            set { _orderedDate = value; }
        }

        public string DateFormatted
        {
            get { return OrderedDate.ToString("dd / MM / yyyy HH:mm"); }
        } 

        public int StoreId
        {
            get { return _storeId };
            set { _storeId = value; }
        }
        #endregion

    }
}
