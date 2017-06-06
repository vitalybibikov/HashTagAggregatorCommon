using System.Collections.Generic;
using System.Threading.Tasks;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Command;
using HashtagAggregator.Core.Contracts.Interface.Cqrs.Query;
using HashtagAggregator.Shared.Common.Infrastructure;

namespace HashtagAggregator.Core.Contracts.Interface.DataSources
{
    public interface IMessageServiceFacade 
    {
        Task<IQueryResult> GetAllAsync(HashTagWord hashtag);

        Task<ICommandResult> Save(IEnumerable<ICommand> filtered);
    }
}
