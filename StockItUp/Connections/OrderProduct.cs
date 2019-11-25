using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class OrderProduct
    {
        private int _orderId;
        private int _productId;
        private int _orderedAmount;
        private int _id;
        private static int _idCounter = 1;

        public OrderProduct(int orderId, int productId, int orderedAmount)
        {
            _orderId = orderId;
            _productId = productId;
            _orderedAmount = orderedAmount;
            _id = _idCounter;
            _idCounter++;
        }

        public OrderProduct()
        {
        }

        public int Order
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public int Product
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public int OrderedAmount
        {
            get { return _orderedAmount; }
            set { _orderedAmount = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
