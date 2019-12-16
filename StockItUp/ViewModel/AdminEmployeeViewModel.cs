using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml;
using RVG.Common;
using StockItUp.Annotations;
using StockItUp.Filter;
using StockItUp.Model;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class AdminEmployeeViewModel : BaseViewModel
    {
        #region Instance fields
        private User _selectedUser = new User(default(string), default(int));
        private PermissionGroup _selectedPermissionGroup = null;
        private string _selectedSort;
        private string _newEmployeeUsername;
        private string _newEmployeePassword;

        #endregion

        #region Constructor

        public AdminEmployeeViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(CreateEmployeeMethod);
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployeeMethod);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployeeMethod);
            ResetPasswordCommand = new RelayCommand(ResetPasswordMethod);
            ShowPassword = Visibility.Collapsed;
            ShowPasswordOnCreate = Visibility.Collapsed;
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
            set
            {
                ShowPasswordOnCreate = Visibility.Collapsed; OnPropertyChanged(nameof(ShowPasswordOnCreate));
                ShowPassword = Visibility.Collapsed; OnPropertyChanged(nameof(ShowPassword));
                _selectedUser = value; OnPropertyChanged();
            }
        }

        public PermissionGroup SelectedPermissionGroup
        {
            get { return _selectedPermissionGroup; }
            set { _selectedPermissionGroup = value; OnPropertyChanged();}
        }

        public string SelectedSort
        {
            get { return _selectedSort; }
            set { _selectedSort = value; OnPropertyChanged(); OnPropertyChanged(nameof(UserCatalog)); OnPropertyChanged(nameof(PermissionGroupCatalog)); }
        }

        public Visibility ShowPassword { get; set; }
        public Visibility ShowPasswordOnCreate { get; set; }

        public ObservableCollection<User> UserCatalog
        {
            get
            {
               List<User> listToReturn = new List<User>(Catalog<User>.Instance.GetList);

               if (SelectedSort == "Navn")
               {
                   listToReturn.Sort(new UserFilterByName());
               }

               if (SelectedSort == "Rolle")
               {
                   listToReturn.Sort(new UserFilterByRole());
               }

               ObservableCollection<User>collection =new ObservableCollection<User>(listToReturn);
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

        public ObservableCollection<string> SortingCollection
        {
            get
            {
                List<string> sortList = new List<string>() { "Navn", "Rolle" };
                return new ObservableCollection<string>(sortList);
            }
        }

        public string NewEmployeeName { get; set; }

        public string NewEmployeeUsername
        {
            get { return _newEmployeeUsername; }
            set { _newEmployeeUsername = value; OnPropertyChanged(); }
        }

        public string NewEmployeePassword
        {
            get { return _newEmployeePassword; }
            set { _newEmployeePassword = value; OnPropertyChanged(); }
        }

        public Controller Controller
        {
            get { return Controller.Instance; }
        }
        #endregion

        #region Methods

        //Methods for CRUD Employees
        private async void CreateEmployeeMethod()
        {
            if(!String.IsNullOrEmpty(NewEmployeeName) && SelectedPermissionGroup != null)
            {
                User tempUser = new User(NewEmployeeName,SelectedPermissionGroup.Id);
                NewEmployeePassword = RandomPasswordMethod();
                NewEmployeeUsername = RandomUserName();
                tempUser.Username = NewEmployeeUsername;
                tempUser.Password = NewEmployeePassword;

                await Catalog<User>.Instance.Create(tempUser);


                OnPropertyChanged(nameof(UserCatalog)); 
               ShowPasswordOnCreate = Visibility.Visible;
                //OnPropertyChanged(nameof(SelectedUser));
                OnPropertyChanged(nameof(ShowPasswordOnCreate));
                NewEmployeeName = "";
                OnPropertyChanged(nameof(NewEmployeeName));
            }
        }

        private async void UpdateEmployeeMethod()
        {
            if (SelectedUser != null)
            {
                if (SelectedPermissionGroup!=null)
                {
                    _selectedUser.GroupId = SelectedPermissionGroup.Id;
                }
                
                await Catalog<User>.Instance.Update(SelectedUser.Id, SelectedUser);
                OnPropertyChanged(nameof(UserCatalog));
            }
        }

        private async void DeleteEmployeeMethod()
        {
            await Catalog<User>.Instance.Delete(SelectedUser.Id);
            OnPropertyChanged(nameof(UserCatalog));
            _selectedUser = new User(default(string), default(int));
            //_selectedPermissionGroup = null;
        }

        //Methods for generating random Passwords and Usernames
        public string RandomPasswordMethod()
        {
            Random ran = new Random();

            string newPassword = "";

            for (int i = 0; i < 4; i++)
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

            foreach (char c in NewEmployeeName)
            {
                if (char.IsUpper(c))
                {
                    s += c;
                }   
            }

            for (int i = 0; i < 2; i++)
            {
                s += ran.Next(1, 10);
            }

            return s;
            
        }


        #endregion


    }
}