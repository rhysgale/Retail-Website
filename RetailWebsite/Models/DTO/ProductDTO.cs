using System;

namespace Models.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

        public Guid ProductId { get; set; }

        public string ProductDescription { get; set; }

        public string MainImage { get; set; }
    }
}
