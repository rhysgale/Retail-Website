using System;
using System.Collections.Generic;
using System.Text;

namespace CartDb.Entities
{
    public class CartSession
    {
        public Guid Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime ExpiresDateTime { get; set; }

        //Virtual
        public virtual IEnumerable<CartSessionDetail> SessionOrderLines { get; set; }
    }
}
