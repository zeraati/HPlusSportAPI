using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HPlusSportAPI.Models
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Products)
                .WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Order>().HasMany(x => x.Products);
            modelBuilder.Entity<Order>().HasOne(x => x.User);

            modelBuilder.Entity<User>().HasMany(x => x.Orders)
                .WithOne(x => x.User).HasForeignKey(x => x.UserId);

            modelBuilder.Seed();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order>Orders{ get; set; }
        public DbSet<Product>Products{ get; set; }
        public DbSet<User>Users{ get; set; }
    }
}
