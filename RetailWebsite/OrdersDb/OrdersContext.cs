using Microsoft.EntityFrameworkCore;
using OrdersDb.Entities;

namespace OrdersDb
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<PartOrder> PartOrders { get; set; }

        public DbSet<PartOrderDetail> PartOrderDetails { get; set; }
    }
}
