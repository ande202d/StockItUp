namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserStore")]
    public partial class UserStore
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public virtual User User { get; set; }
    }
}
