using Microsoft.EntityFrameworkCore;
using ProductsDb.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartProduct>()
                            .HasKey(c => new { c.PartId, c.ProductId });

            modelBuilder.Entity<ProductCategory>()
                            .HasKey(c => new { c.ProductId, c.CategoryId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PartProduct> PartProduct { get; set; }

        public DbSet<ProductCategory> ProductCateory { get; set; }
    }
}
