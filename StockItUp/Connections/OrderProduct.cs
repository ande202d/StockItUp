using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class OrderProduct
    {
        private int _storeId;
        private int _productId;
        private int _orderedAmount;

        public OrderProduct(int storeId, int productId, int orderedAmount)
        {
            _storeId = storeId;
            _productId = productId;
            _orderedAmount = orderedAmount;
        }

        public int StoreId
        {
            get { return _storeId; }
            set { _storeId = value; }
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
