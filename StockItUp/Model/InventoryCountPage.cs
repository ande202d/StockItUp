using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountPage
    {

        private Product _product;
        private int _amount = 0;

        public InventoryCountPage(Product product)
        {
            _product = product;
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }
}
