namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryCount")]
    public partial class InventoryCount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryCount()
        {
            InventoryCountProducts = new HashSet<InventoryCountProduct>();
        }

        public int Id { get; set; }

        public int Location { get; set; }

        public DateTime DateCounted { get; set; }

        public virtual Location Location1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryCountProduct> InventoryCountProducts { get; set; }
    }
}
