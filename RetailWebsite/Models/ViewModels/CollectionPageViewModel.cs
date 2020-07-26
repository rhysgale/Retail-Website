using Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModels
{
    public class CollectionPageViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
