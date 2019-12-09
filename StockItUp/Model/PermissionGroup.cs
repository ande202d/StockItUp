using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class PermissionGroup
    {
        private int _id;
        private static int _idCounter = 1;

        private string _name;

        public PermissionGroup(string name)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
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

        #region Permissions
        //Products
        public bool CanCreateProduct { get; set; }
        public bool CanDeleteProduct { get; set; }
        public bool CanUpdateProduct { get; set; }

        //Suppliers
        public bool CanCreateSupplier { get; set; }
        public bool CanDeleteSupplier { get; set; }
        public bool CanUpdateSupplier { get; set; }

        //Locations
        public bool CanCreateLocation { get; set; }
        public bool CanDeleteLocation { get; set; }
        public bool CanUpdateLocation { get; set; }

        //InventoryCount
        public bool CanCreateInventoryCount { get; set; }
        public bool CanDeleteInventoryCount { get; set; }
        public bool CanViewInventoryCount { get; set; }

        //Order
        public bool CanCreateOrder { get; set; }
        public bool CanDeleteOrder { get; set; }
        public bool CanViewOrder { get; set; }

        //StoreProduct (Wanted products)
        public bool CanChangeStoreProduct { get; set; }

        //Users
        public bool CanCreateUser { get; set; }
        public bool CanDeleteUser { get; set; }
        public bool CanUpdateUser { get; set; }

        //PermissionGroups
        public bool CanCreatePermissionGroup { get; set; }
        public bool CanDeletePermissionGroup { get; set; }
        public bool CanUpdatePermissionGroup { get; set; }

        //Store
        public bool CanCreateStore { get; set; }
        public bool CanDeleteStore { get; set; }
        public bool CanUpdateStore { get; set; }

        #endregion
    }
}
