using OrdersDb;
using Services.Interfaces;

namespace Services.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly OrdersContext _ordersContext;

        public CollectionService(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }
    }
}
