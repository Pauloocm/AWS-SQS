using Amazon.SQS.Model;
using Queue.AWS.SQS.Domain;

namespace Queue.AWS.SQS.Platform
{
    public interface ISqsAppService
    {
        Task<SendMessageResponse> SendMessageToSqsQueue(TicketRequest request);
    }
}
