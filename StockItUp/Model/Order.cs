using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class Order
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;

        private DateTime _dateTime;
        #endregion

        #region Constructors
        public Order(string IsItDefault)
        {
            _id = _idCounter;
            _idCounter++;

            _dateTime = DateTime.Now;
        }

        public Order()
        {

        }
        #endregion

        #region Properties
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
        #endregion
    }
}
