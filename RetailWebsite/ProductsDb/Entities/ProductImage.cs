using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }

        public Guid LinkedToProductId { get; set; }

        public string Url { get; set; }


        //Virtual reference links
        public virtual Product LinkedProduct { get; set; }
    }
}
