using Core.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Orders.Domain;
using Orders.Infrastructure;
using System.Threading.Tasks;

namespace Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IEndpointInstance _endpointInstance;
        IOrderRepository _orderRepository;

        public OrdersController(IEndpointInstance endpointInstance, IOrderRepository orderRepository)
        {
            _endpointInstance = endpointInstance;
            _orderRepository = orderRepository;
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {            
            // Send the command
            await _endpointInstance.Send("Assignment.Orders", new PlaceOrderCommand());
            // Return the order
            return Ok();
        }
    }
}
