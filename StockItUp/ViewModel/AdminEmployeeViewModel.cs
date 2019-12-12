using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class AdminEmployeeViewModel : INotifyPropertyChanged
    {
        #region Instance fields
        private User _selectedUser = new User(default(string), default(int));


        #endregion

        #region Constructor

        public AdminEmployeeViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(CreateEmployeeMethod);
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployeeMethod);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployeeMethod);
            ResetPasswordCommand = new RelayCommand(RandomPasswordMethod);
        }


        #endregion

        #region Commands

        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand ResetPasswordCommand { get; set; }

        #endregion

        #region Properties

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public ObservableCollection<User> UserCatalog
        {
            get
            {
               ObservableCollection<User> collection = new ObservableCollection<User>(Catalog<User>.Instance.GetList);

               return collection;

            }
        }

        public ObservableCollection<PermissionGroup> PermissionGroupCatalog
        {
            get
            {
                ObservableCollection<PermissionGroup> collection = new ObservableCollection<PermissionGroup>(Catalog<PermissionGroup>.Instance.GetList);

                return collection;
            }
        }

        #endregion

        #region Methods

        private async void CreateEmployeeMethod()
        {
            _selectedUser.Password = RandomPasswordMethod();
            await Catalog<User>.Instance.Create(SelectedUser);
            OnPropertyChanged(nameof(UserCatalog));
        }

        private async void UpdateEmployeeMethod()
        {
            if (SelectedUser != null)
            {
                await Catalog<User>.Instance.Update(SelectedUser.Id, SelectedUser);
                OnPropertyChanged(nameof(UserCatalog));
            }
        }

        private async void DeleteEmployeeMethod()
        {
            await Catalog<User>.Instance.Delete(SelectedUser.Id);
            OnPropertyChanged(nameof(UserCatalog));

        }

        public string RandomPasswordMethod()
        {
            Random ran = new Random();

            string newPassword = "";

            for (int i = 0; i < 6; i++)
            {
                string temp = ran.Next(1, 9).ToString();
                newPassword = newPassword + temp;
            }

            return newPassword;
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