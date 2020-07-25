using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersDb.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        public Guid CustomerId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Address4 { get; set; }

        public string PostCode { get; set; }

        public string Country { get; set; }


        //Virtual Links
        public Customer Customer { get; set; }
    }
}
