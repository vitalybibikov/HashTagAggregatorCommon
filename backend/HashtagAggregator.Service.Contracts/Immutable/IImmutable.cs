namespace HashtagAggregator.Service.Contracts.Immutable
{
    public interface IFreezeImmutable
    {
        bool Freezed { get; }

        void Freeze();
    }
}
