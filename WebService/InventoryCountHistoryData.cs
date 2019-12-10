namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InventoryCountHistoryData")]
    public partial class InventoryCountHistoryData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Product { get; set; }

        public int Amount { get; set; }

        public int InventoryCountHistory { get; set; }

        public int AmountPerBox { get; set; }

        public virtual InventoryCountHistory InventoryCountHistory1 { get; set; }
    }
}
