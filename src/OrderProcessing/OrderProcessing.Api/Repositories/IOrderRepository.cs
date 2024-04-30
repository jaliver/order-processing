using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Repositories
{
    public interface IOrderRepository
    {
        Task<IReadOnlyCollection<Order>> AddOrders(IReadOnlyCollection<Order> orders);
        Task<IReadOnlyCollection<Order>> UpdateOrders(IReadOnlyCollection<Order> orders);
    }
}
