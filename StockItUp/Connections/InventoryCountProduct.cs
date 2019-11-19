using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class InventoryCountProduct
    {
        private int _inventoryCountId;
        private int _productId;
        private int _amount;

        public InventoryCountProduct(int inventoryCountId, int productId, int amount)
        {
            _inventoryCountId = inventoryCountId;
            _productId = productId;
            _amount = amount;
        }

        public InventoryCountProduct()
        {
        }

        public int InventoryCountId
        {
            get { return _inventoryCountId; }
            set { _inventoryCountId = value; }
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
