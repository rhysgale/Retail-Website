using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Request;
using Models.ViewModels;
using Services.Interfaces;

namespace RetailWebsite.Controllers.MvControllers
{
    public class CheckoutController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;

        public CheckoutController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
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

        public IActionResult ConfirmationPage(Guid orderId)
        {
            var vm = new ConfirmationPageViewModel()
            {
                OrderId = orderId
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult EnterDetails()
        {
            Byte[] sessionByteArray;
            HttpContext.Session.TryGetValue("SessionId", out sessionByteArray);

            Guid? sessionId;
            if (sessionByteArray == null)
                return RedirectToAction("Index"); //empty

            return View();
        }

        [HttpPost]
        public IActionResult PlaceOrder(PlaceOrderRequest request)
        {
            Byte[] sessionByteArray;
            HttpContext.Session.TryGetValue("SessionId", out sessionByteArray);

            Guid? sessionId;
            if (sessionByteArray != null)
                sessionId = new Guid(sessionByteArray);
            else
                return RedirectToAction("Index"); //empty

            var orderId = _orderService.PlaceOrder(sessionId.Value, request);

            HttpContext.Session.Clear();

            return RedirectToAction("ConfirmationPage", new { orderId });
        }
    }
}