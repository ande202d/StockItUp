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
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Product { get; set; }

        public int Amount { get; set; }

        public virtual InventoryCountHistory InventoryCountHistory { get; set; }
    }
}
