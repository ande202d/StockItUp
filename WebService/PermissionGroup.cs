namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PermissionGroup")]
    public partial class PermissionGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionGroup()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public bool CanCreateProduct { get; set; }

        public bool CanDeleteProduct { get; set; }

        public bool CanUpdateProduct { get; set; }

        public bool CanCreateSupplier { get; set; }

        public bool CanDeleteSupplier { get; set; }

        public bool CanUpdateSupplier { get; set; }

        public bool CanCreateLocation { get; set; }

        public bool CanDeleteLocation { get; set; }

        public bool CanUpdateLocation { get; set; }

        public bool CanCreateInventoryCount { get; set; }

        public bool CanDeleteInventoryCount { get; set; }

        public bool CanViewInventoryCount { get; set; }

        public bool CanCreateOrder { get; set; }

        public bool CanDeleteOrder { get; set; }

        public bool CanViewOrder { get; set; }

        public bool CanChangeStoreProduct { get; set; }

        public bool CanCreateUser { get; set; }

        public bool CanDeleteUser { get; set; }

        public bool CanUpdateUser { get; set; }

        public bool CanCreatePermissionGroup { get; set; }

        public bool CanDeletePermissionGroup { get; set; }

        public bool CanUpdatePermissionGroup { get; set; }

        public bool CanCreateStore { get; set; }

        public bool CanDeleteStore { get; set; }

        public bool CanUpdateStore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
