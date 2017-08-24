using System;
using System.Text;
using HashtagAggregator.Shared.Common.Extensions;

namespace HashtagAggregator.Core.Entities.VkEntities
{
    public class VkMessageQuery : VkQuery
    {
        private const string AccessTokenName = "access_token";
        private readonly string serviceToken;

        public VkMessageQuery(string baseUrl, string version, string serviceToken) : base(baseUrl, version)
        {
            this.serviceToken = serviceToken;
        }

        public string Query { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool Extended { get; set; } = true;

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());
            builder.Append("&q=");
            builder.Append(Encode(Query));
            builder.Append("&extended=");
            builder.Append(Encode(Convert.ToInt32(Extended).ToString()));
            if (StartTime.HasValue)
            {
                builder.Append("&start_time=");
                builder.Append(StartTime.Value.ToUnixTime());
            }
            if (EndTime.HasValue)
            {
                builder.Append("&end_time=");
                builder.Append(EndTime.Value.ToUnixTime());
            }
            builder.Append($"&{AccessTokenName}=");
            builder.Append(serviceToken);
            return builder.ToString();
        }
    }
}