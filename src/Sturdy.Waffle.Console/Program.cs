using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace Sturdy.Waffle.Console
{
    internal static class Program
    {
        private static IConfiguration _configuration;
        private static IHostEnvironment _environment;

        private static async Task Main(string[] args) => await Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("Sturdy.Waffle.Configuration.json");
                _configuration = builder.Build();

                hostingContext.HostingEnvironment.EnvironmentName =
                    Environment.GetEnvironmentVariable("STURDY_WAFFLE_ENVIRONMENT");
                _environment = hostingContext.HostingEnvironment;
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();

                var log = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .Enrich.FromLogContext()
                    .WriteTo.Console(
                        outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {SourceContext} {Message}{NewLine}{Exception}",
                        theme: AnsiConsoleTheme.Code)
                    .CreateLogger();

                logging.AddSerilog(log);
            })
            .ConfigureServices(services =>
            {
                
            })
            .RunConsoleAsync();
    }
}
