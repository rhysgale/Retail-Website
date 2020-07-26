using Microsoft.EntityFrameworkCore;
using Models.DTO;
using OrdersDb;
using ProductsDb;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PartOrderingService : IPartOrderingService
    {
        private readonly ProductsContext _productsContext;
        private readonly OrdersContext _ordersContext;

        public PartOrderingService(ProductsContext productsContext, OrdersContext ordersContext)
        {
            _productsContext = productsContext;
            _ordersContext = ordersContext;
        }

        public IEnumerable<DetailLineDTO> GetOrderDetails(Guid orderId, string email)
        {
            var order = _ordersContext.Orders.Include(x => x.OrderDetails).Include(x => x.Address).ThenInclude(x => x.Customer).FirstOrDefault(x => x.Address.Customer.Email == email && x.Id == orderId);
            if (order == null)
                return null;

            var products = _productsContext.Products.Where(x => order.OrderDetails.Select(y => y.ProductId).Contains(x.Id));


            List<DetailLineDTO> list = new List<DetailLineDTO>();
            foreach (var prod in products)
            {
                list.Add(new DetailLineDTO()
                {
                    ProductId = prod.Id,
                    ProductName = prod.Name,
                    Quantity = order.OrderDetails.First(x => x.ProductId == prod.Id).Quantity,
                    UnitCost = prod.Price
                });
            }

            return list;
        }
    }
}
