using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class InventoryCountHistoryData
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private string _product;
        private int _amount;
        private int _inventoryCountHistoryId;
        private int _amountPerBox;
        #endregion


        #region Constructors
        public InventoryCountHistoryData(int inventoryCountHistoryId, string product, int amount, int amountPerBox)
        {
            _id = _idCounter;
            _idCounter++;

            _product = product;
            _amount = amount;
            _inventoryCountHistoryId = inventoryCountHistoryId;
            _amountPerBox = amountPerBox;
        }

        public InventoryCountHistoryData()
        {
        } 
        #endregion

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

        public int AmountPerBox
        {
            get { return _amountPerBox; }
            set { _amountPerBox = value; }
        }

        public int NumberOfBoxes
        {
            get { return (int)Math.Floor((double)Amount / AmountPerBox); }
        }

        public int NumberOfLoose
        {
            get { return Amount - (NumberOfBoxes*AmountPerBox);}
        }

        #endregion

    }
}
