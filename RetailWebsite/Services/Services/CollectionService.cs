using Microsoft.EntityFrameworkCore;
using Models.DTO;
using ProductsDb;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ProductsContext _productsContext;

        public CollectionService(ProductsContext productsContext)
        {
            _productsContext = productsContext;
        }

        public IEnumerable<ProductDTO> GetCollection(Guid categoryId)
        {
            //Get products linked to the category
            var products = _productsContext.Products
                                .Include(x => x.CategoryLinks)
                                .ThenInclude(x => x.Category)
                                .Where(x => x.CategoryLinks.Any(y => y.CategoryId == categoryId))
                                .Select(x => new ProductDTO()
                                {
                                    ProductName = x.Name,
                                    MainImage = x.MainImageUrl,
                                    ProductDescription = x.Description
                                });

            return products;
        }
    }
}
