using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class DetailLineDTO
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal UnitCost { get; set; }

        public int Quantity { get; set; }

        public decimal LineTotalCost
        {
            get
            {
                return UnitCost * Quantity;
            }
        }
    }
}
