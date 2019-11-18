namespace WebService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StockItUpDBContext : DbContext
    {
        public StockItUpDBContext()
            : base("name=StockItUpDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<InventoryCount> InventoryCounts { get; set; }
        public virtual DbSet<InventoryCountHistory> InventoryCountHistories { get; set; }
        public virtual DbSet<InventoryCountHistoryData> InventoryCountHistoryDatas { get; set; }
        public virtual DbSet<InventoryCountProduct> InventoryCountProducts { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
        public virtual DbSet<OrderHistoryData> OrderHistoryDatas { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreProduct> StoreProducts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryCount>()
                .HasMany(e => e.InventoryCountProducts)
                .WithRequired(e => e.InventoryCount1)
                .HasForeignKey(e => e.InventoryCount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCountHistory>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<InventoryCountHistory>()
                .HasMany(e => e.InventoryCountHistoryDatas)
                .WithRequired(e => e.InventoryCountHistory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryCountHistoryData>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.InventoryCounts)
                .WithRequired(e => e.Location1)
                .HasForeignKey(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Order1)
                .HasForeignKey(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderHistory>()
                .HasMany(e => e.OrderHistoryDatas)
                .WithRequired(e => e.OrderHistory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderHistoryData>()
                .Property(e => e.Product)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.InventoryCountProducts)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.StoreProducts)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.Locations)
                .WithRequired(e => e.Store1)
                .HasForeignKey(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Store>()
                .HasMany(e => e.StoreProducts)
                .WithRequired(e => e.Store1)
                .HasForeignKey(e => e.Store)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Website)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Supplier1)
                .HasForeignKey(e => e.Supplier);
        }
    }
}
