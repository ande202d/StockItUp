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

        public Order(string IsItDefault)
        {
            _id = _idCounter;
            _idCounter++;

            _dateTime = DateTime.Now;
        }

        public Order()
        {
            
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime OrderDate
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
    }
}
