using System.Threading.Tasks;

namespace HashtagAggregator.Core.Contracts.Interface.Cqrs.Query
{
    public interface IQueryHandler<in TParameter, TResult>
        where TResult : IQueryResult, new()
        where TParameter : IQuery
    {
        Task<TResult> GetAsync(TParameter query);
    }
}
