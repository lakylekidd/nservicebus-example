using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Orders.Commands;
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

        [HttpPost]
        public async Task<ActionResult> Create()
        {
            // Create a new random order
            var order = OrderAggregate.Create();
            // Save order in database
            await _orderRepository.Create(order);
            // Send the command
            await _endpointInstance.Send(new PlaceOrderCommand(order.AggregateId));

            return Ok(order);
        }
    }
}
