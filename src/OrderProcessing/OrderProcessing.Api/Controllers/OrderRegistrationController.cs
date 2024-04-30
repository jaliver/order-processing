using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Api.Models;

namespace OrderProcessing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderRegistrationController : ControllerBase
    {
        public OrderRegistrationController()
        {
        }

        [HttpPost("orders")]
        public Receipt CreateOrders()
        {
            throw new NotImplementedException();
        }
    }
}
