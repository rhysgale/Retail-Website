using CartDb;
using Models.Request;
using OrdersDb;
using OrdersDb.Entities;
using ProductsDb;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrdersContext _ordersContext;
        private readonly CartContext _cartContext;
        private readonly ProductsContext _productContext;

        public OrderService(OrdersContext orderContext, CartContext cartContext, ProductsContext productContext)
        {
            _ordersContext = orderContext;
            _cartContext = cartContext;
            _productContext = productContext;
        }

        public Guid PlaceOrder(Guid sessionId, PlaceOrderRequest request)
        {
            var detailLines = _cartContext.CartSessionDetails.Where(x => x.CartSessionId == sessionId);
            var productIds = detailLines.Select(x => x.ProductId);
            var products = _productContext.Products.Where(x => productIds.Contains(x.Id));

            var customerId = GetCustomer(request);

            var address = new Address()
            {
                Id = Guid.NewGuid(),
                Address1 = request.Address1,
                Address2 = request.Address2,
                Address3 = request.Address3,
                Address4 = request.Address4,
                PostCode = request.Postcode,
                CustomerId = customerId
            };
            _ordersContext.Add(address);

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                DateOrderPlaced = DateTime.Now,
                AddressId = address.Id
            };
            _ordersContext.Add(order);

            foreach (var detail in detailLines)
            {
                var detailLine = new OrderDetail()
                {
                    Id = Guid.NewGuid(),
                    OrderId = order.Id,
                    ProductId = detail.ProductId,
                    Quantity = detail.Quantity
                };

                _ordersContext.Add(detailLine);
            }

            _ordersContext.SaveChanges();

            return order.Id; //Our new order ref
        }

        private Guid GetCustomer(PlaceOrderRequest request)
        {
            var cust = _ordersContext.Customers.FirstOrDefault(x => x.Email == request.Email);
            if (cust == null)
            {
                cust = new Customer()
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    Id = Guid.NewGuid()
                };

                _ordersContext.Add(cust);
                _ordersContext.SaveChanges();
            }

            return cust.Id;
        }
    }
}
