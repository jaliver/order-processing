using OrderProcessing.Api.Models;
using OrderProcessing.Api.Repositories;

namespace OrderProcessing.Api.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderProcessingService(IOrderRepository orderRepository)
        {
            ArgumentNullException.ThrowIfNull(orderRepository, nameof(orderRepository));

            _orderRepository = orderRepository;
        }

        public async Task<Receipt> ProcessOrders(IReadOnlyCollection<Order> orders)
        {
            var addedOrders = await _orderRepository.AddOrders(orders);

            foreach (var addedOrder in addedOrders)
            {
                addedOrder.IsProcessed = true;
            }

            var processedOrders = await _orderRepository.UpdateOrders(addedOrders);

            return new Receipt
            {
                Orders = processedOrders,
                ProcessedDateTime = DateTime.UtcNow
            };
        }
    }
}
