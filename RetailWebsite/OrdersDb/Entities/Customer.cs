using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersDb.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        //Virtual Links
        public IEnumerable<Address> Addresses { get; set; }
    }
}
