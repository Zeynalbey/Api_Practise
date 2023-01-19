using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using WebApplication4.Database.Model;

namespace WebApplication4.Database
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new() { Id = 1, Name = "Elektronika" },
                new() { Id = 2, Name = "Erzaq" });

            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
             .HasData(
                     new()
                     {
                         Id = 1,
                         Name = "Tv",
                         Price = 850,
                         dateTime = DateTime.Now.AddDays(-3),
                         CategoryId = 1

                     },
                     new()
                     {
                         Id = 2,
                         Name = "Computer",
                         Price = 700,
                         dateTime = DateTime.Now.AddDays(-50),
                         CategoryId = 1
                     },
                     new()
                     {
                         Id = 3,
                         Name = "Mobile-phone",
                         Price = 200,
                         dateTime = DateTime.Now.AddDays(-12),
                         CategoryId = 1
                     }
                 );
            base.OnModelCreating(modelBuilder);
        }
    }
}
