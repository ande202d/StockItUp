﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class InventoryCountProduct
    {
        #region Instance fields

        private int _inventoryCountId;
        private int _productId;
        private int _amount;
        private int _id;
        private static int _idCounter = 1;

        #endregion

        #region Constructor
        public InventoryCountProduct(int inventoryCountId, int productId, int amount)
        {
            _inventoryCountId = inventoryCountId;
            _productId = productId;
            _amount = amount;
            _id = _idCounter;

            InventoryCount = inventoryCountId;
            Product = productId;
            Amount = amount;
            Id = _idCounter;
            _idCounter++;
        }
        public InventoryCountProduct()
        {
        }
        #endregion


        #region Properties
        public int InventoryCount
        {
            get { return _inventoryCountId; }
            set { _inventoryCountId = value; }
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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        } 
        #endregion
    }
}
