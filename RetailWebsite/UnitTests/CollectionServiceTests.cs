using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
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
    public class CollectionServiceTests
    {
        private readonly ICollectionService _service;

        private readonly ServiceProvider _serviceProvider;
        private readonly ServiceCollection _serviceCollection;

        public CollectionServiceTests()
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

            _service = new CollectionService(db);
        }

        [Fact]
        public void CollectionServiceReturnsCorrectProducts()
        {
            var catId = _serviceProvider.GetService<ProductsContext>().Categories.First().Id;

            var products = _service.GetCollection(catId);

            Assert.True(products.Count() == 1);
            Assert.Contains("Hot Wheels", products.First().ProductName);
        }
    }
}
