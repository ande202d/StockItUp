using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
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
        private PermissionGroup _selectedPermissionGroup = new PermissionGroup(default(string));

        #endregion

        #region Constructor

        public AdminEmployeeViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(CreateEmployeeMethod);
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployeeMethod);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployeeMethod);
            ResetPasswordCommand = new RelayCommand(ResetPasswordMethod);
            ShowPassword = Visibility.Collapsed;
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

        public PermissionGroup SelectedPermissionGroup
        {
            get { return _selectedPermissionGroup; }
            set { _selectedPermissionGroup = value; OnPropertyChanged(); }
        }

        public Visibility ShowPassword { get; set; }

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

        //Methods for CRUD Employees
        private async void CreateEmployeeMethod()
        {
            if(String.IsNullOrEmpty(SelectedUser.Name))
            {
                _selectedUser.GroupId = SelectedPermissionGroup.Id;
                _selectedUser.Password = RandomPasswordMethod();
                _selectedUser.Username = RandomUserName();
                await Catalog<User>.Instance.Create(SelectedUser);
                OnPropertyChanged(nameof(UserCatalog));
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private async void UpdateEmployeeMethod()
        {
            if (SelectedUser != null)
            {
                _selectedUser.GroupId = SelectedPermissionGroup.Id;
                await Catalog<User>.Instance.Update(SelectedUser.Id, SelectedUser);
                OnPropertyChanged(nameof(UserCatalog));
            }
        }

        private async void DeleteEmployeeMethod()
        {
            await Catalog<User>.Instance.Delete(SelectedUser.Id);
            OnPropertyChanged(nameof(UserCatalog));

        }

        //Methods for generating random Passwords and Usernames
        public string RandomPasswordMethod()
        {
            Random ran = new Random();

            string newPassword = "";

            for (int i = 0; i < 6; i++)
            {
                string temp = ran.Next(1, 9).ToString();
                newPassword += temp;
            }

            return newPassword;
        }

        public void ResetPasswordMethod()
        {
            _selectedUser.Password = RandomPasswordMethod(); OnPropertyChanged(nameof(SelectedUser));
            ShowPassword = Visibility.Visible; OnPropertyChanged(nameof(ShowPassword));
        }

        public string RandomUserName()
        {
            Random ran = new Random();
            string s = "";

            foreach (Char c in _selectedUser.Name)
            {
                if (Char.IsUpper(c))
                {
                    s += c;
                }

                for (int i = 0; i < 2; i++)
                {
                    s += ran.Next(1, 10);
                }
            }

            return s;
            
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