namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHistoryData")]
    public partial class OrderHistoryData
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Product { get; set; }

        public int MissingAmount { get; set; }

        public int AmountPerBox { get; set; }

        public int RecommendedAmount { get; set; }

        public int AmountOrdered { get; set; }

        public virtual OrderHistory OrderHistory { get; set; }
    }
}
