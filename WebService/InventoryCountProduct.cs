namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryCountProduct")]
    public partial class InventoryCountProduct
    {
        public int Id { get; set; }

        public int InventoryCount { get; set; }

        public int Product { get; set; }

        public int Amount { get; set; }

        public virtual InventoryCount InventoryCount1 { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
