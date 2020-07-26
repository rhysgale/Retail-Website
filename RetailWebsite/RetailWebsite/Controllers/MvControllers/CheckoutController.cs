using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RetailWebsite.Controllers.MvControllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            Byte[] sessionByteArray;
            HttpContext.Session.TryGetValue("", out sessionByteArray);

            Guid? sessionId;
            if (sessionByteArray != null)
                sessionId = new Guid(sessionByteArray);

            return View();
        }
    }
}