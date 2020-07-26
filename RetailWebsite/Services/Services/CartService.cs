using CartDb;
using CartDb.Entities;
using Microsoft.AspNetCore.Http;
using Models.DTO;
using ProductsDb;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class CartService : ICartService
    {
        private readonly CartContext _cartContext;
        private readonly ProductsContext _productContext;

        public CartService(CartContext cartContext, ProductsContext productContext)
        {
            _cartContext = cartContext;
            _productContext = productContext;
        }

        public Guid AddToBasket(Guid? sessionId, Guid productId)
        {
            var newSessionId = sessionId ?? Guid.NewGuid();

            var product = _productContext.Products.First(x => x.Id == productId);
            var session = GetSession(newSessionId);

            var cartDetails = _cartContext.CartSessionDetails.FirstOrDefault(x => x.ProductId == productId && x.CartSessionId == newSessionId);
            if (cartDetails == null)
            {
                var detail = new CartSessionDetail()
                {
                    CartSessionId = newSessionId,
                    Id = Guid.NewGuid(),
                    Price = product.Price,
                    ProductId = productId,
                    ProductName = product.Name,
                    Quantity = 1
                };
                _cartContext.Add(detail);
            }
            else
            {
                cartDetails.Quantity++;
            }

            _cartContext.SaveChanges();

            return newSessionId;
        }

        public IEnumerable<DetailLineDTO> GetCustomerCart(Guid sessionId)
        {
            //Get customer cart details
            var details = _cartContext.CartSessionDetails.Where(x => x.CartSessionId == sessionId)
                                                    .Select(x => new
                                                    {
                                                        x.ProductId,
                                                        x.Quantity
                                                    })
                                                    .ToList();

            //Get all the products in our customers cart
            var products = _productContext.Products.Where(x => details.Select(y => y.ProductId).Contains(x.Id));

            //Generate a new model to display for the customer on basket page
            List<DetailLineDTO> detailLines = new List<DetailLineDTO>();
            foreach (var product in products)
            {
                var detailLine = new DetailLineDTO()
                {
                    ProductId = product.Id,
                    UnitCost = product.Price,
                    Quantity = details.First(x => x.ProductId == product.Id).Quantity,
                    ProductName = product.Name
                };
                detailLines.Add(detailLine);
            }

            return detailLines;
        }

        private CartSession GetSession(Guid sessionId)
        {
            var session = _cartContext.CartSessions.FirstOrDefault(x => x.Id == sessionId);
            if (session == null || session.ExpiresDateTime < DateTime.Now)
            {
                session = new CartSession()
                {
                    CreateDateTime = DateTime.Now,
                    ExpiresDateTime = DateTime.Now.AddHours(1),
                    Id = sessionId
                };

                _cartContext.Add(session);
                _cartContext.SaveChanges();
            }

            return session;
        }
    }
}
