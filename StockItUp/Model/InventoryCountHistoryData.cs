using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountHistoryData
    {
        private int _id; //the id from the inventoryCountHistory witch is also the same as the InventoryCount
        private string _product;
        private int _amount;

        //Something simular the inventoryCountHistory
        //where it takes a InventoryCount, and then finds the matching inventoryCountProducts
        public InventoryCountHistoryData(int id, string product, int amount)
        {
            _id = id;
            _product = product;
            _amount = amount;
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

        public string Product1
        {
            get { return _product; }
            set { _product = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        } 
        #endregion

    }
}
