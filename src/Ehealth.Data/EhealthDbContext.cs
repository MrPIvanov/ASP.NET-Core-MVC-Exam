using Ehealth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Data
{
    public class EhealthDbContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }


        public EhealthDbContext(DbContextOptions<EhealthDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CartProduct>()
            .HasKey(cp => new { cp.ProductId, cp.CartId });

            base.OnModelCreating(builder);
        }
    }
}
