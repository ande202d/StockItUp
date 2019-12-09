using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Annotations;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {

        #region Instance field

        private Store _selectedStore;

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            
        }


        #endregion

        #region Properties

        public string Username { get; set; }
        
        public string Password { get; set; }

        public Store SelectedStore
        {
            get { return _selectedStore; }
            set { _selectedStore = value; }
        }

        public ObservableCollection<Store> StoreCatalog
        {
            get
            {
                return new ObservableCollection<Store>(Catalog<Store>.Instance.GetList);
            }
        }

        #endregion

        #region Methods

        public void LoginMethod()
        {
            foreach (User u in Catalog<User>.Instance.GetList)
            {
                if (u.Username == Username)
                {
                    if (u.Password == Password)
                    {
                        Controller.Instance.UserId = u.Id;

                        Controller.Instance.StoreId = SelectedStore.Id;
                        break;
                    }
                }
            }
        }

        #endregion

        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion


    }

}
