using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersDb.Entities
{
    public class PartOrder
    {
        public Guid Id { get; set; }

        public Guid AddressId { get; set; }

        public DateTime DateOrderPlaced { get; set; }

        //Virtual links
        public virtual Address Address { get; set; }
        public virtual IEnumerable<PartOrderDetail> OrderDetails { get; set; }
    }
}
