using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountPage
    {

        #region Instance fields
        private Product _product;
        private int _amount = 0;
        private int _boxAmount = 0;
        #endregion

        #region Constructor
        public InventoryCountPage(Product product)
        {
            _product = product;
        }

        #endregion

        #region Properties
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

        public int BoxAmount
        {
            get { return _boxAmount; }
            set { _boxAmount = value; }
        } 
        #endregion
    }
}
