using System;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;

namespace RetailWebsite.Controllers.MvControllers
{
    public class CollectionPageController : Controller
    {
        private readonly ICollectionService _collectionService;

        public CollectionPageController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        public IActionResult Index(Guid? categoryId)
        {
            var vm = new CollectionPageViewModel()
            {
                Products = _collectionService.GetCollection(categoryId)
            };

            return View(vm);
        }
    }
}