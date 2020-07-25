﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsDb;

namespace ProductsDb.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductsDb.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProductsDb.Entities.Part", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PartDescription");

                    b.Property<string>("PartImageUrl");

                    b.Property<string>("PartName");

                    b.HasKey("Id");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("ProductsDb.Entities.PartProduct", b =>
                {
                    b.Property<Guid>("PartId");

                    b.Property<Guid>("ProductId");

                    b.HasKey("PartId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("PartProduct");
                });

            modelBuilder.Entity("ProductsDb.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("MainImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsDb.Entities.ProductCategory", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCateory");
                });

            modelBuilder.Entity("ProductsDb.Entities.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("LinkedProductId");

                    b.Property<Guid>("LinkedToProductId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("LinkedProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("ProductsDb.Entities.PartProduct", b =>
                {
                    b.HasOne("ProductsDb.Entities.Part", "Part")
                        .WithMany("ProductLinks")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsDb.Entities.Product", "Product")
                        .WithMany("PartLinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductsDb.Entities.ProductCategory", b =>
                {
                    b.HasOne("ProductsDb.Entities.Category", "Category")
                        .WithMany("ProductLinks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProductsDb.Entities.Product", "Product")
                        .WithMany("CategoryLinks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductsDb.Entities.ProductImage", b =>
                {
                    b.HasOne("ProductsDb.Entities.Product", "LinkedProduct")
                        .WithMany("ProductImages")
                        .HasForeignKey("LinkedProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
