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
        public int Id { get; set; }

        public int Order { get; set; }

        public int Product { get; set; }

        public int OrderedAmount { get; set; }

        public virtual Order Order1 { get; set; }

        public virtual Product Product1 { get; set; }
    }
}
