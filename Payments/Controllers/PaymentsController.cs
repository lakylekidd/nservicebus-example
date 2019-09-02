using Microsoft.AspNetCore.Mvc;
using Payments.Infrastructure;
using System.Threading.Tasks;

namespace Payments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet("all")]
        public async Task<ActionResult> GetPayments()
        {
            var payments = await _paymentRepository.GetAll();
            return Ok(payments);
        }

    }
}