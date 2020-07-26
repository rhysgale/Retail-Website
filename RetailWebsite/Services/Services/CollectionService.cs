using Microsoft.EntityFrameworkCore;
using Models.DTO;
using ProductsDb;
using ProductsDb.Entities;
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

        public IEnumerable<ProductDTO> GetCollection(Guid? categoryId)
        {
            //Get products linked to the category
            IEnumerable<Product> products = _productsContext.Products
                                .Include(x => x.CategoryLinks)
                                .ThenInclude(x => x.Category);

            if (categoryId != null)
            {
                products = products.Where(x => x.CategoryLinks.Any(y => y.CategoryId == categoryId)).AsEnumerable();
            }
                                
            return products.Select(x => new ProductDTO()
            {
                ProductName = x.Name,
                MainImage = x.MainImageUrl,
                ProductDescription = x.Description,
                ProductId = x.Id
            });
        }
    }
}
