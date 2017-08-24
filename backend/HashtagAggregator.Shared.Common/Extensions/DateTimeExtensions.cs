using System;

namespace HashtagAggregator.Shared.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToUnixTime(this DateTime offset)
        {
            var utc = offset.ToUniversalTime();
            return (int)utc.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}
