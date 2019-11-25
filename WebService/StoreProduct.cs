namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoreProduct")]
    public partial class StoreProduct
    {
        public int Id { get; set; }

        public int Store { get; set; }

        public int Product { get; set; }

        public int Amount { get; set; }

        public virtual Product Product1 { get; set; }

        public virtual Store Store1 { get; set; }
    }
}
