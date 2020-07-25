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
        public virtual Part Part { get; set; }

        public virtual Product Product { get; set; }
    }
}
