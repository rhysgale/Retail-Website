using Models.DTO;
using System;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Guid AddToBasket(Guid? sessionId, Guid productId);

        CustomerCartDTO GetCustomerCart(Guid sessionId);
    }
}
