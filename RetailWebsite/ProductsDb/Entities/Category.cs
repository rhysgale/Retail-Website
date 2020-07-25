using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        //Virtual References
        public virtual IEnumerable<ProductCategory> ProductLinks { get; set; }  //Many to Many relationship, ProductCategory
    }
}
