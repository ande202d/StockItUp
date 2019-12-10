﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {

        #region Instance field

        private Store _selectedStore;
        private string _username;
        private string _password;
        #endregion

        #region Constructor

        public LoginViewModel()
        {
            //LoginCommand = new RelayCommand(LoginMethod);
        }


        #endregion

        #region Commands

        //public ICommand LoginCommand { get; set; }

        #endregion

        #region Properties

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public Store SelectedStore
        {
            get { return _selectedStore; }
            set { _selectedStore = value; OnPropertyChanged();}
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

        public bool LoginMethod()
        {
            if (SelectedStore != null)
            {
                foreach (User u in Catalog<User>.Instance.GetList)
                {
                    if (u.Username == Username)
                    {
                        if (u.Password == Password)
                        {
                            Controller.Instance.UserId = u.Id;

                            Controller.Instance.StoreId = SelectedStore.Id;
                            return true;
                        }
                    }
                }
            }

            return true;
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