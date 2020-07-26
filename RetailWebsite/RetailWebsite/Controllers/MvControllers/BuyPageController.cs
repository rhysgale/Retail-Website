using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index(Guid id)
        {
            var vm = new BuyPageViewModel()
            {
                Product = _productService.GetProduct(id)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddToBasket(Guid productId) //productID
        {
            Byte[] value = null;
            int? basketCount = HttpContext.Session.GetInt32("BasketCount");
            if (basketCount != null)
            {
                basketCount++;
                HttpContext.Session.SetInt32("BasketCount", basketCount.Value);
            }
            else
                HttpContext.Session.SetInt32("BasketCount", 1); //Only one if session doesn't already exist!


            HttpContext.Session.TryGetValue("SessionId", out value);

            Guid? sessionId = null;
            if (value != null)
                sessionId = new Guid(value);

            var newSessionId = _cartService.AddToBasket(sessionId, productId);

            HttpContext.Session.Set("SessionId", newSessionId.ToByteArray());

            return RedirectToAction("Index", new { id = productId });
        }
    }
}