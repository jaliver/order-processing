using OrderProcessing.Api.Data;
using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<Order>> AddOrders(IReadOnlyCollection<Order> orders)
        {
            var addedOrders = new List<Order>();

            foreach (var order in orders)
            {
                var addedOrderEntry = await _dbContext.Set<Order>().AddAsync(order);
                addedOrders.Add(addedOrderEntry.Entity);
            }

            await _dbContext.SaveChangesAsync();

            return addedOrders;
        }

        public async Task<IReadOnlyCollection<Order>> UpdateOrders(IReadOnlyCollection<Order> orders)
        {
            var updatedOrders = new List<Order>();

            foreach (var order in orders)
            {
                var updatedOrder = _dbContext.Set<Order>().Update(order);
                updatedOrders.Add(updatedOrder.Entity);
            }
            
            await _dbContext.SaveChangesAsync();

            return updatedOrders;
        }
    }
}
