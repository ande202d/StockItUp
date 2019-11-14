using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class InventoryCountProduct
    {
        private int _storeId;
        private int _productId;
        private int _amount;

        public InventoryCountProduct(int storeId, int productId, int amount)
        {
            _storeId = storeId;
            _productId = productId;
            _amount = amount;
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
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
