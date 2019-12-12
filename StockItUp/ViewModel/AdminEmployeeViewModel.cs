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

        private Catalog<User> _userCatalog;
        private User _selectedUser;


        #endregion

        #region Constructor

        public AdminEmployeeViewModel()
        {
            CreateEmployeeCommand = new RelayCommand(CreateEmployeeMethod);
            UpdateEmployeeCommand = new RelayCommand(UpdateEmployeeMethod);
            DeleteEmployeeCommand = new RelayCommand(DeleteEmployeeMethod);
        }


        #endregion

        #region Commands

        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }

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
               ObservableCollection<User> collection = new ObservableCollection<User>(_userCatalog.GetList);

               return collection;

            }
        }

        #endregion

        #region Methods

        private async void CreateEmployeeMethod()
        {
            //
        }

        private async void UpdateEmployeeMethod()
        {
            //
        }

        private async void DeleteEmployeeMethod()
        {
            await _userCatalog.Delete(SelectedUser.Id);
            OnPropertyChanged(nameof(UserCatalog));

        }

        public void ResetPassword()
        {
            //
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