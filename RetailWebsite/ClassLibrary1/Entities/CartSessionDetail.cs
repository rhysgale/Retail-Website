using System;
using System.Collections.Generic;
using System.Text;

namespace CartDb.Entities
{
    public class CartSessionDetail
    {
        public Guid Id { get; set; }

        public Guid CartSessionId { get; set; }

        public decimal Price { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }


        //Virtual
        public virtual CartSession CartSession { get; set; }
    }
}
