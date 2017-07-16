namespace HashtagAggregator.Service.Contracts.Queues
{
    public class QueueParams
    {
        private string name;
        private string serverName;

        public string ServerName => serverName;

        public string Name => name;

        public QueueParams(string name, string serverName)
        {
            this.name = name;
            this.serverName = serverName;
        }

        public override string ToString()
        {
            return $"{serverName}-{name}";
        }
    }
}