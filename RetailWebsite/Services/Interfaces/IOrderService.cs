using Models.Request;
using System;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        Guid PlaceOrder(Guid sessionId, PlaceOrderRequest request);
    }
}
