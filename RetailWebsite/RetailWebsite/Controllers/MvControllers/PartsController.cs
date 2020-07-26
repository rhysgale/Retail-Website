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
    public class PartsController : Controller
    {
        private readonly IPartOrderingService _partOrderingService;

        public PartsController(IPartOrderingService partOrderingService)
        {
            _partOrderingService = partOrderingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ViewDetails(ViewDetailsRequest request)
        {
            var details = _partOrderingService.GetOrderDetails(request.OrderReference, request.EmailAddress);

            var vm = new ViewOrderDetailsViewModel()
            {
                DetailLines = details
            };

            return View(vm);
        }
    }
}