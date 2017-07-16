using System.Collections.Generic;
using Hangfire.Storage;

namespace HashtagAggregator.Service.Contracts
{
    public interface IStorageAccessor
    {
        List<RecurringJobDto> GetJobsList();

        void CancelRecurringJobs();
    }
}
