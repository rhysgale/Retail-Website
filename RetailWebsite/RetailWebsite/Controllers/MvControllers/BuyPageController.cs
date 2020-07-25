using System;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;

namespace RetailWebsite.Controllers.MvControllers
{
    public class BuyPageController : Controller
    {
        private readonly IProductService _productService;

        public BuyPageController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index(Guid id)
        {
            var vm = new BuyPageViewModel()
            {
                Product = _productService.GetProduct(id)
            };

            return View(vm);
        }
    }
}