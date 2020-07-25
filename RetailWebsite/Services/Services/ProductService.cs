using Models.DTO;
using ProductsDb;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsContext _productsContext;

        public ProductService(ProductsContext productContext)
        {
            _productsContext = productContext;
        }

        public ProductDTO GetProduct(Guid productId)
        {
            return _productsContext.Products
                                    .Where(x => x.Id == productId)
                                    .Select(x => new ProductDTO()
                                    {
                                        MainImage = x.MainImageUrl,
                                        ProductDescription = x.Description,
                                        ProductId = x.Id,
                                        ProductName = x.Name
                                    })
                                    .First();
        }
    }
}
