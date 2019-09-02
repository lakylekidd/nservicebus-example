using Microsoft.AspNetCore.Mvc;
using Notifications.Infrastructure;
using Payments.Infrastructure;
using System.Threading.Tasks;

namespace Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetMessages()
        {
            var messages = await _messageRepository.GetAll();
            return Ok(messages);
        }

    }
}