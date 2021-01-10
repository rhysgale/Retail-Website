using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.ViewModels;
using Services.Interfaces;

namespace RetailWebsite.Controllers.MvControllers
{
    public class BuyPageController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public BuyPageController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public IActionResult Index(Guid productId)
        {
            var vm = new BuyPageViewModel()
            {
                Product = _productService.GetProduct(productId)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddToBasket(AddToBasketRequest request) //productID
        {
            int basketCount = (HttpContext.Session.GetInt32("BasketCount") ?? 0) + 1;
            HttpContext.Session.SetInt32("BasketCount", basketCount);
            HttpContext.Session.TryGetValue("SessionId", out byte[] value);

            Guid? sessionId = null;
            if (value != null)
                sessionId = new Guid(value);

            var newSessionId = _cartService.AddToBasket(sessionId, request.ProductId);

            HttpContext.Session.Set("SessionId", newSessionId.ToByteArray());

            return RedirectToAction("Index", new { productId = request.ProductId });
        }
    }
}