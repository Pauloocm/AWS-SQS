using Microsoft.AspNetCore.Mvc;
using Queue.AWS.SQS.Domain;
using Queue.AWS.SQS.Platform;

namespace Queue.AWS.SQS.Controllers
{
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ISqsAppService sqsService;

        public QueueController(ISqsAppService sqsAppService)
        {
            sqsService = sqsAppService;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(TicketRequest request)
        {
            var response = await sqsService.SendMessageToSqsQueue(request);

            if (response is null)
                return BadRequest();

            return Ok();
        }
    }
}
