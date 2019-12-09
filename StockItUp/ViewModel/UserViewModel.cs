using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockItUp.Persistency;

namespace StockItUp.ViewModel
{
    public class UserViewModel
    {


        public Controller GetController
        {
            get { return Controller.Instance;}
        }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public void ChangePasswordMethod()
        {
            if (OldPassword == GetController.GetUser.Password && !String.IsNullOrWhiteSpace(NewPassword))
            {
                GetController.GetUser.Password = NewPassword;
                OldPassword = default(string);
                NewPassword = default(string);
            }
        }
    }
}
