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
                DetailLines = details,
                Email = request.EmailAddress,
                OrderReference = request.OrderReference
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult DetailSelected(DetailSelectedRequest request)
        {
            var parts = _partOrderingService.GetPartsForDetail(request);

            var vm = new ViewPartsViewModel()
            {
                Parts = parts,
                EmailAddress = request.EmailAddress,
                OrderId = request.OrderReference,
                ProductId = request.ProductId
            };

            return View(vm);
        }
    }
}