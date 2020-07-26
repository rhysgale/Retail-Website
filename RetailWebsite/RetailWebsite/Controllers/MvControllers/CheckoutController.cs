using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;

namespace RetailWebsite.Controllers.MvControllers
{
    public class CheckoutController : Controller
    {
        private readonly ICartService _cartService;

        public CheckoutController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            Byte[] sessionByteArray;
            HttpContext.Session.TryGetValue("SessionId", out sessionByteArray);

            Guid? sessionId;
            if (sessionByteArray != null)
                sessionId = new Guid(sessionByteArray);
            else
                return View(new CustomerCartViewModel()); //empty

            var cartDetails = _cartService.GetCustomerCart(sessionId.Value);

            return View(new CustomerCartViewModel()
            {
                DetailLines = cartDetails
            });
        }
    }
}