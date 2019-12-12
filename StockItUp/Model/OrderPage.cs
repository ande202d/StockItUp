using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class OrderPage
    {

        #region Instance field

        private Product _product;
        private int _amountInStorage;
        private int _missing;
        private int _suggestedAmount;
        private int _actualAmount = 0;
        private Supplier _supplier;

        #endregion

        #region Constructor

        public OrderPage(Product product, int amountInStorage, int missing, int suggestedAmount  ,Supplier supplier)
        {
            _product = product;
            _amountInStorage = amountInStorage;
            _missing = missing;
            _suggestedAmount = suggestedAmount;
            _supplier = supplier;
        }




        #endregion

        #region Properties

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public int AmountInStorage
        {
            get { return _amountInStorage; }
            set { _amountInStorage = value; }
        }

        public int Missing
        {
            get { return _missing; }
            set { _missing = value; }
        }

        public int SuggestedAmount
        {
            get { return _suggestedAmount; }
            set { _suggestedAmount = value; }
        }

        public int ActualAmount
        {
            get { return _actualAmount; }
            set { _actualAmount = value; }
        }

        public Supplier Supplier
        {
            get
            {
                if (_supplier == null) return null;
                return _supplier;
            }
            set { _supplier = value; }
        }

        public string SupplierName
        {
            get
            {
                if (Supplier == null) return "Ingen leverandør";
                return Supplier.Name;
            }
        }

        #endregion
    }
}
