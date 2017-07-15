using System.Threading.Tasks;

using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregator.Service.Contracts
{
    public interface ISocialJobBalancer
    {
        Task<ICommandResult> TryCreateJob(string tag);

        ICommandResult DeleteJob(string tag);
    }
}