namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderProduct")]
    public partial class OrderProduct
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product { get; set; }

        public int OrderedAmount { get; set; }

        public virtual Order Order1 { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
