using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;

namespace HashtagAggregator.Service.Contracts
{
    public interface IBackgroundServiceWorker
    {
        Task<ICommandResult> Start(string tag);

        void Stop(string tag);
    }
}