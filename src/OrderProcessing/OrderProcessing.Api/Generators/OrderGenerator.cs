using OrderProcessing.Api.Models;
using OrderProcessing.Api.Settings;

namespace OrderProcessing.Api.Generators
{
    public class OrderGenerator : IOrderGenerator
    {
        private readonly ISettings _settings;

        public OrderGenerator(ISettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings, nameof(settings));

            _settings = settings;
        }
        public IReadOnlyCollection<Order> GenerateConfiguredNumberOfOrders()
        {
            var configuredNumberOfOrders = _settings.GetIntSetting("OrderGenerator:NumberOfOrders");

            var orders = new List<Order>();

            var createdDate = DateTime.UtcNow;

            for (var i = 0; i < configuredNumberOfOrders; i++)
            {
                orders.Add(new Order
                {
                    CustomerName = Guid.NewGuid().ToString(),
                    CreatedDate = createdDate
                });
            }

            return orders;
        }
    }
}
