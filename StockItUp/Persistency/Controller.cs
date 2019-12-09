using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Persistency
{
    public class Controller
    {
        private int _userId;
        private int _storeId;

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

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        /*
        public User GetUser
        {
            get {return Catalog<User>.Instance.read(UserId).Result;}
        }
        */

        public int StoreId
        {
            get { return _storeId; }
            set { _storeId = value; }
        }

    }
}
