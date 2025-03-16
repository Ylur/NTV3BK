using Microsoft.EntityFrameworkCore;

namespace SalesDatabase.Models
{
    /// <summary>
    /// The Entity Framework database context that manages your tables (DbSets).
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Setup composite keys and relationships.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for OrderItem (OrderId + ProductId)
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

            // Additional relationship or constraint configuration if needed.
            // e.g., modelBuilder.Entity<OrderItem>()
            //        .HasOne(oi => oi.Order)
            //        .WithMany(o => o.OrderItems)
            //        .HasForeignKey(oi => oi.OrderId);

            // e.g., modelBuilder.Entity<OrderItem>()
            //        .HasOne(oi => oi.Product)
            //        .WithMany(p => p.OrderItems)
            //        .HasForeignKey(oi => oi.ProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}