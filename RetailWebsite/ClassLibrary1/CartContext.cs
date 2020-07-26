using CartDb.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartDb
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options)
            : base(options)
        {
        }

        public DbSet<CartSession> CartSessions { get; set; }

        public DbSet<CartSessionDetail> CartSessionDetails { get; set; }
    }
}
