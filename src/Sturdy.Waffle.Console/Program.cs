using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Sturdy.Waffle.Console
{
    internal class Program
    {
        private static IConfiguration _configuration;
        private static IHostEnvironment _environment;

        private static async Task Main(string[] args) => await Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("Sturdy.Waffle.Configuration.json");
                _configuration = builder.Build();

                _environment = hostingContext.HostingEnvironment;
            })
            .ConfigureServices(services =>
            {

            })
            .RunConsoleAsync();
    }
}
