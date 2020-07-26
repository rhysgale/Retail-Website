using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersDb.Entities
{
    public class OrderDetail
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        //Virtual product links
        public virtual Order Order { get; set; }
    }
}
