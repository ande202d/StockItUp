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
        public int Id { get; set; }

        public int OrderHistory { get; set; }

        [Required]
        [StringLength(50)]
        public string Product { get; set; }

        public int MissingAmount { get; set; }

        public int AmountPerBox { get; set; }

        public int RecommendedAmount { get; set; }

        public int AmountOrdered { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier { get; set; }
        public string Email { get; set; }

        public virtual OrderHistory OrderHistory1 { get; set; }
    }
}
