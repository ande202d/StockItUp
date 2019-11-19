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

        public OrderProduct(int orderId, int productId, int orderedAmount)
        {
            _orderId = orderId;
            _productId = productId;
            _orderedAmount = orderedAmount;
        }

        public OrderProduct()
        {
        }

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public int OrderedAmount
        {
            get { return _orderedAmount; }
            set { _orderedAmount = value; }
        }
    }
}
