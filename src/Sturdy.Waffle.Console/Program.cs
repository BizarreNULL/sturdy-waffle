using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                var connectionString = _environment.IsDevelopment()
                    ? _configuration.GetConnectionString("Development")
                    : _configuration.GetConnectionString("Production");

                if (string.IsNullOrEmpty(connectionString))
                    throw new ArgumentNullException(nameof(connectionString));

                services.AddDbContext<ApplicationContext>(builder => builder.UseSqlite(connectionString));
            })
            .RunConsoleAsync();
    }
}
