using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Solution.CrossCutting.AspNetCore.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfiguration Build(this IConfigurationBuilder configuration, IHostingEnvironment environment)
        {
            return configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json")
                .AddJsonFile($"AppSettings.{environment.EnvironmentName}.json")
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
