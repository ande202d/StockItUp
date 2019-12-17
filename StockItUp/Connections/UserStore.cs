using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Connections
{
    public class UserStore
    {
        #region instance fields
        private int _id;
        private static int _idCounter = 1;
        private int _userId;
        private int _storeId;
        #endregion

        #region Constructors
        public UserStore(int userId, int storeId)
        {
            _id = _idCounter;
            _idCounter++;

            _userId = userId;
            _storeId = storeId;
        }
        public UserStore()
        {
        }
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int StoreId
        {
            get { return _storeId; }
            set { _storeId = value; }
        } 
        #endregion
    }
}
