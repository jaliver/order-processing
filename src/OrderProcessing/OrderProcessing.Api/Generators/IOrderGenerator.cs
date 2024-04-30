using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Generators
{
    public interface IOrderGenerator
    {
        IReadOnlyCollection<Order> GenerateConfiguredNumberOfOrders();
    }
}
