using Amazon.SQS;
using Amazon.SQS.Model;
using Queue.AWS.SQS.Domain;
using System.Text.Json;

namespace Queue.AWS.SQS.Platform
{
    public class SqsAppService : ISqsAppService
    {
        private readonly IAmazonSQS amazonSqs;

        public SqsAppService(IAmazonSQS amazonSqsService)
        {
            amazonSqs = amazonSqsService;
        }

        public async Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request)
        {
            var sendMessageRequest = new SendMessageRequest()
            {
                QueueUrl = "https://sqs.us-west-2.amazonaws.com/307671859681/TicketRequest",
                MessageBody = request.Serialize(request)
            };

            return await amazonSqs.SendMessageAsync(sendMessageRequest);
        }
    }
}
