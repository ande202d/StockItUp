using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Calls;

namespace StockItUp.Model
{
    public class User
    {
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private string _username;
        private string _password;
        private int _phoneNumber;
        private int _groupId;

        public User(string name, int groupId)
        {
            _id = _idCounter;
            _idCounter++;
            _name = name;
            _groupId = groupId;
            _phoneNumber = 0;
            RandomUsername();
            _password = _username;
        }

        public User()
        {
            
        }

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
            //Name initials
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

        // Random username method 
        public void RandomUsername()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[5];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            _username = new string(stringChars);
        }

    }
}
