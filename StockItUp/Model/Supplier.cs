using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp
{
    public class Supplier: IComparable<Supplier>
    {
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        private string _website;

        #region Constructor
        public Supplier(string name, string website)
        {
            _id = _idCounter;
            _idCounter++;
            _name = name;

            //if (CheckWebsite(website)) _website = website;
            //else throw new Exception("Email must contain: @");
            _website = website;
        }

        public Supplier()
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
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        #endregion

        #region Methods
        public bool CheckWebsite(string s)
        {
            return s.Contains("@");
        } 
        #endregion

        public int CompareTo(Supplier other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
