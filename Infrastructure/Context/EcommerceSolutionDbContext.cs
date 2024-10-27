using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class EcommerceSolutionDbContext : IdentityDbContext<ApplicationUser>
    {
        public EcommerceSolutionDbContext(DbContextOptions<EcommerceSolutionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Relacionamento entre ApplicationUser e Address (via chave estrangeira)
            builder.Entity<Address>()
                .HasOne<ApplicationUser>()
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Customer e ApplicationUser (via chave estrangeira)
            builder.Entity<Customer>()
                .HasOne<ApplicationUser>()
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre Employee e ApplicationUser (via chave estrangeira)
            builder.Entity<Employee>()
                .HasOne<ApplicationUser>()
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre Employee e Position
            builder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento entre CreditCardInfo e Customer
            builder.Entity<CreditCardInfo>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CreditCards)
                .HasForeignKey(cc => cc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre ShoppingCart e Customer
            builder.Entity<ShoppingCart>()
                .HasOne(sc => sc.Customer)
                .WithOne(c => c.ShoppingCart)
                .HasForeignKey<ShoppingCart>(sc => sc.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre Order e Customer
            builder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre OrderItem e Order
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre OrderItem e Product
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre OrderItem e Product
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relação entre ShoppingCart e ShoppingCartItem
            builder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relação entre Product e ShoppingCartItem
            builder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(sci => sci.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
