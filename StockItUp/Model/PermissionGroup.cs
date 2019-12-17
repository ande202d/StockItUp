using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockItUp.Model
{
    public class PermissionGroup
    {
        #region Instance fields
        private int _id;
        private static int _idCounter = 1;
        private string _name;
        #endregion

        #region Constructors
        public PermissionGroup(string name)
        {
            _id = _idCounter;
            _idCounter++;

            _name = name;
        }

        public PermissionGroup()
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

        //We relate a string to a bool
        public List<KeyValuePair<string, bool>> GetPermissions
        {
            get
            {
                List<KeyValuePair<string, bool>> listToReturn = new List<KeyValuePair<string, bool>>()
                {
                    new KeyValuePair<string, bool>("Kan oprette produkt", CanCreateProduct),
                    new KeyValuePair<string, bool>("Kan slette produkt", CanDeleteProduct),
                    new KeyValuePair<string, bool>("Kan redigere produkt", CanUpdateProduct),
                    new KeyValuePair<string, bool>("Kan oprette leverandør", CanCreateSupplier),
                    new KeyValuePair<string, bool>("Kan slette leverandør", CanDeleteSupplier),
                    new KeyValuePair<string, bool>("Kan redigere leverandør", CanUpdateSupplier),
                    new KeyValuePair<string, bool>("Kan oprette lokation", CanCreateLocation),
                    new KeyValuePair<string, bool>("Kan slette lokation", CanDeleteLocation),
                    new KeyValuePair<string, bool>("Kan redigere lokation", CanUpdateLocation),
                    new KeyValuePair<string, bool>("Kan oprette optælling", CanCreateInventoryCount),
                    new KeyValuePair<string, bool>("kan slette optælling", CanDeleteInventoryCount),
                    new KeyValuePair<string, bool>("Kan se optælling", CanViewInventoryCount),
                    new KeyValuePair<string, bool>("Kan oprette bestilling", CanCreateOrder),
                    new KeyValuePair<string, bool>("Kan slette bestilling", CanDeleteOrder),
                    new KeyValuePair<string, bool>("Kan se bestilling", CanViewOrder),
                    new KeyValuePair<string, bool>("Kan ændre ønsket lager", CanChangeStoreProduct),
                    new KeyValuePair<string, bool>("Kan oprette bruger", CanCreateUser),
                    new KeyValuePair<string, bool>("Kan slette bruger", CanDeleteUser),
                    new KeyValuePair<string, bool>("Kan redigere bruger", CanUpdateUser),
                    new KeyValuePair<string, bool>("Kan oprette brugerolle", CanCreatePermissionGroup),
                    new KeyValuePair<string, bool>("Kan slette brugerrolle", CanDeletePermissionGroup),
                    new KeyValuePair<string, bool>("Kan redigere brugerrolle", CanUpdatePermissionGroup),
                    new KeyValuePair<string, bool>("Kan oprette butik", CanCreateStore),
                    new KeyValuePair<string, bool>("Kan slette butik", CanDeleteStore),
                    new KeyValuePair<string, bool>("Kan redigere butik", CanUpdateStore)
                };
                return listToReturn;
            } 
            

        }
        #endregion

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
