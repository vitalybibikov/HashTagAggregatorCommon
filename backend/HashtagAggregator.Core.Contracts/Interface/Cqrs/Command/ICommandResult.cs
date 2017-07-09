namespace HashtagAggregator.Core.Contracts.Interface.Cqrs.Command
{
    public interface ICommandResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }
}