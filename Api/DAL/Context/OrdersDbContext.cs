using Microsoft.EntityFrameworkCore;
using Roxosoft.Orders.Api.DAL.Dto;

namespace Roxosoft.Orders.Api.DAL.Context {
    public class OrdersDbContext : DbContext {
        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public DbSet<ProductDto> Products { get; set; }
        public DbSet<OrderDto> Orders { get; set; }
        public DbSet<OrderProductDto> OrderProducts { get; set; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ProductDto>().ToTable("Product");
            modelBuilder.Entity<ProductDto>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductDto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductDto>().Property(p => p.Name).IsRequired().HasMaxLength(255);

            modelBuilder.Entity<OrderDto>().ToTable("Order");
            modelBuilder.Entity<OrderDto>().HasKey(p => p.Id);
            modelBuilder.Entity<OrderDto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderDto>().Property(p => p.CreationTime).IsRequired();
            modelBuilder.Entity<OrderDto>().Property(p => p.Status).IsRequired();

            modelBuilder.Entity<OrderProductDto>().ToTable("OrderProduct");
            modelBuilder.Entity<OrderProductDto>().HasKey(p => p.Id);
            modelBuilder.Entity<OrderProductDto>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderProductDto>().Property(p => p.OrderId).IsRequired();
            modelBuilder.Entity<OrderProductDto>().Property(p => p.ProductId).IsRequired();
            modelBuilder.Entity<OrderProductDto>().Property(p => p.Price).IsRequired();
            modelBuilder.Entity<OrderProductDto>().Property(p => p.Quantity).IsRequired();

            modelBuilder.Entity<OrderProductDto>()
                .HasOne(op => op.Product)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(op => op.ProductId);
            modelBuilder.Entity<OrderProductDto>()
                .HasOne(op => op.Order)
                .WithMany(op => op.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            //заполним базу изначальными данными
            OrdersInitialDataCreator.Create(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}