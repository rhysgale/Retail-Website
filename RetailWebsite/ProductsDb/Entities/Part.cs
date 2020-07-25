using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsDb.Entities
{
    public class Part
    {
        public Guid Id { get; set; }

        public string PartName { get; set; }

        public string PartDescription { get; set; }

        public string PartImageUrl { get; set; }

        //Virtual Links
        public virtual IEnumerable<PartProduct> ProductLinks { get; set; }
    }
}
