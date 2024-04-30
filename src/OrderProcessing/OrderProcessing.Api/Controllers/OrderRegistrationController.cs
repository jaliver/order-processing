using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Api.Generators;
using OrderProcessing.Api.Models;
using OrderProcessing.Api.Services;

namespace OrderProcessing.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderRegistrationController : ControllerBase
    {
        private readonly IOrderGenerator _orderGenerator;
        private readonly IOrderProcessingService _orderProcessingService;

        public OrderRegistrationController(IOrderGenerator orderGenerator, IOrderProcessingService orderProcessingService)
        {
            ArgumentNullException.ThrowIfNull(orderGenerator, nameof(orderGenerator));
            ArgumentNullException.ThrowIfNull(orderProcessingService, nameof(orderProcessingService));

            _orderGenerator = orderGenerator;
            _orderProcessingService = orderProcessingService;
        }

        [HttpPost("orders")]
        public async Task<Receipt> CreateOrders()
        {
            var orders = _orderGenerator.GenerateConfiguredNumberOfOrders();

            return await _orderProcessingService.ProcessOrders(orders);
        }
    }
}
