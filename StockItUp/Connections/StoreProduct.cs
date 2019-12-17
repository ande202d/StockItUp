using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class StoreProduct
    {
        #region Instance fields
        private int _storeId;
        private int _productId;
        private int _amount;
        private int _id;
        private static int _idCounter = 1;
        #endregion

        #region Constructors
        public StoreProduct(int storeId, int productId, int amount)
        {
            _storeId = storeId;
            _productId = productId;
            _amount = amount;
            //_id = _idCounter;
            //_idCounter++;
        }

        public StoreProduct()
        {
        }
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Store
        {
            get { return _storeId; }
            set { _storeId = value; }
        }
        public int Product
        {
            get { return _productId; }
            set { _productId = value; }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        } 
        #endregion
    }
}
