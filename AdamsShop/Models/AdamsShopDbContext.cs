using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdamsShop.DataModel;

namespace AdamsShop.Models
{
    public class AdamsShopDbContext : IdentityDbContext
    {
        public AdamsShopDbContext(DbContextOptions<AdamsShopDbContext> options) : base(options)
        {
        }

        /* protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pie>().Property(x => x.Price).HasPrecision(9,2);
        } */
        public DbSet<Category> Categories { get; set; }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
} 
