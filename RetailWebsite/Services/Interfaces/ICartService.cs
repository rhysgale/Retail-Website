using Models.DTO;
using System;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Guid AddToBasket(Guid? sessionId, Guid productId);

        IEnumerable<DetailLineDTO> GetCustomerCart(Guid sessionId);
    }
}
