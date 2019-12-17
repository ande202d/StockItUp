using System;
using System.Collections.Generic;
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
    public class UserViewModel : BaseViewModel
    {

        private User _dummyUser;

        #region Constructor
        public UserViewModel()
        {
            UpdateUserCommand = new RelayCommand(UpdateUserMethod);
            _dummyUser = Controller.Instance.GetUser;
        } 
        #endregion

        #region Commands
        public ICommand UpdateUserCommand { get; set; }
        #endregion

        #region Properties

        public PermissionGroup Permission
        {
            get { return Catalog<PermissionGroup>.Instance.Read(Controller.Instance.GetUser.GroupId).Result; }
        }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public string UserName
        {
            get { return _dummyUser.Name; }
            set { _dummyUser.Name = value; }
        }

        public bool CanAccessAdminPage
        {
            get
            {
                if (Permission.CanCreateUser || Permission.CanDeleteUser || Permission.CanUpdateUser ||
                    Permission.CanCreatePermissionGroup || Permission.CanDeletePermissionGroup ||
                    Permission.CanUpdatePermissionGroup || Permission.CanCreateStore || Permission.CanUpdateStore ||
                    Permission.CanDeleteStore)
                {
                    return true;
                }

                return false;
            }
        }

        public int UserPhoneNumber
        {
            get { return _dummyUser.PhoneNumber; }
            set { _dummyUser.PhoneNumber = value; }
        }

        public string UserUsername
        {
            get { return _dummyUser.Username; }
            set { _dummyUser.Username = value; }
        }

        public Controller GetController
        {
            get { return Controller.Instance; }
        }
        #endregion

        #region Methods
        public async void UpdateUserMethod()
        {
            if (OldPassword == GetController.GetUser.Password)
            {
                if (!String.IsNullOrWhiteSpace(NewPassword)) _dummyUser.Password = NewPassword;

                await Catalog<User>.Instance.Update(Controller.Instance.GetUser.Id, _dummyUser);
                OldPassword = default(string);
                NewPassword = default(string);
                OnPropertyChanged(nameof(OldPassword));
                OnPropertyChanged(nameof(NewPassword));
            }
        }
        #endregion




    }
}
