using System;
using System.Linq;
using HashtagAggregator.Data.DataAccess.Interface;
using HashtagAggregator.Shared.Logging;
using Microsoft.Extensions.Logging;

namespace HashtagAggregator.Data.DataAccess.Seed
{
    public class DbSeeder : IDbSeeder
    {
        private readonly ILogger<DbSeeder> logger;

        public DbSeeder(ILogger<DbSeeder> logger)
        {
            this.logger = logger;
        }

        public void Seed(string connectionString)
        {
            DbConnector dbConnector = null;
            try
            {
                dbConnector = new DbConnector(connectionString);
                var commands = ScriptsRetriever.GetNonQueryScripts().ToArray();
                dbConnector.ExecuteNonQuery(commands);
            }
            catch (Exception ex)
            {
                logger.LogError(
                    LoggingEvents.SEED_ERROR,
                    "Failed to updated the db.",
                    ex);
                throw;
            }
            finally
            {
                dbConnector?.Dispose();
            }
        }
    }
}