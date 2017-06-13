using Microsoft.WindowsAzure.Storage.Queue;

namespace HashtagAggregator.Service.Contracts.Queues
{
    public interface IAzureQueueInitializer
    {
        CloudQueue Queue { get; }
    }
}
