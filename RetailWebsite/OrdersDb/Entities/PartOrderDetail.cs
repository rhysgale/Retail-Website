using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersDb.Entities
{
    public class PartOrderDetail
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid PartId { get; set; }

        //Virtual product links
        public virtual PartOrder Order { get; set; }
    }
}
