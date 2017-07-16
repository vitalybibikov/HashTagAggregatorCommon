using System.Threading.Tasks;

namespace HashtagAggregator.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandHandler<in TParameter> 
        where TParameter : ICommand, new()
    {
        Task<ICommandResult> ExecuteAsync(TParameter command);
    }
}
