using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountHistoryData
    {
        private int _id;
        private static int _idCounter = 1;
        private string _product;
        private int _amount;
        private int _inventoryCountHistoryId;


        //Something simular the inventoryCountHistory
        //where it takes a InventoryCount, and then finds the matching inventoryCountProducts
        public InventoryCountHistoryData(int inventoryCountHistoryId, string product, int amount)
        {
            _id = _idCounter;
            _idCounter++;

            _product = product;
            _amount = amount;
            _inventoryCountHistoryId = inventoryCountHistoryId;
        }

        public InventoryCountHistoryData()
        {
        }

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int InventoryCountHistory
        {
            get { return _inventoryCountHistoryId; }
            set { _inventoryCountHistoryId = value; }
        }

        #endregion

    }
}
