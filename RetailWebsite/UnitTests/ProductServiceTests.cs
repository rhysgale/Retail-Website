using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductsDb;
using ProductsDb.Entities;
using Services.Interfaces;
using Services.Services;
using System;
using System.Linq;
using Xunit;

namespace UnitTests
{
    public class ProductServiceTests
    {
        private readonly IProductService _service;

        private readonly ServiceProvider _serviceProvider;
        private readonly ServiceCollection _serviceCollection;

        public ProductServiceTests()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddDbContext<ProductsContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
                ServiceLifetime.Scoped,
                ServiceLifetime.Scoped);

            _serviceProvider = _serviceCollection.BuildServiceProvider();
            var db = _serviceProvider.GetService<ProductsContext>();

            var category = new Category()
            {
                CategoryName = "Kids Toys",
                Id = Guid.NewGuid()
            };

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Hot Wheels Ford Focus ST",
                Description = "A toy car made of plastic and metal shaped like the stunning ford focus ST",
                MainImageUrl = "https://www.main-image.com"
            };

            var prodCatLink = new ProductCategory()
            {
                CategoryId = category.Id,
                ProductId = product.Id,
                Product = product,
                Category = category
            };

            db.Add(category);
            db.Add(product);
            db.Add(prodCatLink);
            db.SaveChanges();

            _service = new ProductService(db);
        }

        [Fact]
        public void CollectionServiceReturnsCorrectProducts()
        {
            var db = _serviceProvider.GetService<ProductsContext>();
            var id = db.Products.First().Id;

            var product = _service.GetProduct(id);

            Assert.True(product != null);
            Assert.Contains("Hot Wheels", product.ProductName);
        }
    }
}
