using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderHistoryData
    {
        private int _id;
        private string _product;
        private int _missingAmount;
        private int _amountPerBox;
        private int _recomendedAmount;
        private int _amountOrdered;

        public OrderHistoryData(int id, string product, int missingAmount, int amountPerBox, int recomendedAmount, int amountOrdered)
        {
            _id = id;
            _product = product;
            _missingAmount = missingAmount;
            _amountPerBox = amountPerBox;
            _recomendedAmount = recomendedAmount;
            _amountOrdered = amountOrdered;
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

        public int MissingAmount
        {
            get { return _missingAmount; }
            set { _missingAmount = value; }
        }

        public int AmountPerBox
        {
            get { return _amountPerBox; }
            set { _amountPerBox = value; }
        }

        public int RecomendedAmount
        {
            get { return _recomendedAmount; }
            set { _recomendedAmount = value; }
        }

        public int AmountOrdered
        {
            get { return _amountOrdered; }
            set { _amountOrdered = value; }
        } 
        #endregion

    }
}
