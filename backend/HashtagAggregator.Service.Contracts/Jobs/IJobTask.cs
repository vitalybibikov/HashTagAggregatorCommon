using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Service.Contracts.Jobs
{
    public interface IJobTask
    {
        int Interval { get; }

        HashTagWord Tag { get; }

        string JobId { get; }
    }
}
