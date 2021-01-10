using System;

namespace Models.Request
{
    public class AddToBasketRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
