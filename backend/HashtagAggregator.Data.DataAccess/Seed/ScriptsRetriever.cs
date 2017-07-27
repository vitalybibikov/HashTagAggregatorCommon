using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HashtagAggregator.Data.DataAccess.Seed
{
    public static class ScriptsRetriever
    {
        public static IEnumerable<string> GetNonQueryScripts()
        {
            var commands = new List<string>();
            var assembly = typeof(ScriptsRetriever).GetTypeInfo().Assembly;
            var resource = assembly.GetManifestResourceStream("HashtagAggregator.Data.DataAccess.Seed.Scripts.Initial.sql");

            using (var reader = new StreamReader(resource))
            {
                var content =  reader.ReadToEnd();
                commands.Add(content);
            }

            return commands;
        }
    }
}
