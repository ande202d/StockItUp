using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Model;

namespace StockItUp.Persistency
{
    public class Controller
    {
        #region Instance fields
        private int? _userId;
        private int _storeId; 
        #endregion

        #region Singleton
        private static Controller _instance;

        public static Controller Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Controller();
                }
                return _instance;
            }
        }
        #endregion

        #region Properties
        public int? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public User GetUser
        {
            get
            {
                if (UserId != null) return Catalog<User>.Instance.Read((int)UserId).Result;
                return null;
            }
        }

        public int StoreId
        {
            get { return _storeId; }
            set { _storeId = value; }
        }

        public Store GetStore
        {
            get { return Catalog<Store>.Instance.Read(StoreId).Result; }
        } 
        #endregion

    }
}
