using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MainImageUrl { get; set; }

        //Virtual references for joins
        public virtual IEnumerable<ProductImage> ProductImages { get; set; }
        public virtual IEnumerable<Category> Categories { get; set; } //Many to Many relationship, ProductCategory
        public virtual IEnumerable<Part> Parts { get; set; }//Many to Many relationship, PartProduct. Spare parts for the product
    }
}
