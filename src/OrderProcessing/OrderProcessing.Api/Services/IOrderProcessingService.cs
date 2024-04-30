using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Services
{
    public interface IOrderProcessingService
    {
        Task<Receipt> ProcessOrders(IReadOnlyCollection<Order> orders);
    }
}
