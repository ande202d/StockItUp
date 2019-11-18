using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class Order
    {
        private int _id;
        private static int _idCounter = 1;

        private DateTime _dateTime;

        public Order()
        {
            _id = _idCounter;
            _idCounter++;

            _dateTime = DateTime.Now;
        }

        public int Id
        {
            get { return _id; }
        }

        public DateTime Time
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
    }
}
