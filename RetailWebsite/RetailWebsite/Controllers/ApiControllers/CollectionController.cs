using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services.Interfaces;

namespace RetailWebsite.Controllers.ApiControllers
{
    [Route("[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> Collection(Guid categoryId)
        {
            return _collectionService.GetCollection(categoryId);
        }
    }
}