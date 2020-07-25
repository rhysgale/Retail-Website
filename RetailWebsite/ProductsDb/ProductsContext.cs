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

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<PartProduct> PartProduct { get; set; }

        public DbSet<ProductCategory> ProductCateory { get; set; }
    }
}
