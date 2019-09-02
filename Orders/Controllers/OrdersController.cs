using Core.Messages.Commands;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Orders.Domain;
using Orders.Infrastructure;
using System;
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

        [HttpGet("all")]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpGet("place")]
        public async Task<ActionResult> PlaceOrder()
        {            
            // Send the command
            await _endpointInstance.Send("Assignment.Orders", new PlaceOrderCommand());
            // Return the order
            return Ok();
        }

        [HttpGet("cancel")]
        public async Task<ActionResult> CancelOrder([FromBody] Guid id)
        {
            // Send the command
            await _endpointInstance.Send("Assignment.Orders", new CancelOrderCommand(id));
            // Return the order
            return Ok();
        }
    }
}
