using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductsDb.Entities
{
    public class ProductCategory
    {
        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }


        //Virtual references
        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }
    }
}
