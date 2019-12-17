using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;
using StockItUp.Persistency;

namespace StockItUp.Model
{
    public class User
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private string _username;
        private string _password;
        private int _phoneNumber;
        private int _groupId;
        #endregion

        #region Constructors
        public User(string name, int groupId)
        {
            _id = _idCounter;
            _idCounter++;
            _name = name;
            _groupId = groupId;
            _phoneNumber = 0;
        }

        public User()
        {

        }
        #endregion

        #region Properties
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Initials
        {
            //Name initials from uppercase letters
            get
            {
                string s = "";
                foreach (Char c in Name)
                {
                    if (Char.IsUpper(c))
                    {
                        s += c;
                    }

                }

                return s;
            }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public string GroupName
        {
            get { return Catalog<PermissionGroup>.Instance.Read(GroupId).Result.Name; }
        } 
        #endregion

    }
}
