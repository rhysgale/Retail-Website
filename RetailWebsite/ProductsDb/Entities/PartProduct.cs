using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb.Entities
{
    public class PartProduct
    {
        public Guid PartId { get; set; }

        public Guid ProductId { get; set; }

        //Virtual Links
        public Part Part { get; set; }

        public Product Product { get; set; }
    }
}
