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
    public class UserViewModel : INotifyPropertyChanged
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
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public string UserName
        {
            get { return _dummyUser.Name; }
            set { _dummyUser.Name = value; }
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
