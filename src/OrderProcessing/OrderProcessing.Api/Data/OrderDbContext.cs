using Microsoft.EntityFrameworkCore;
using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Order { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
    }
}
