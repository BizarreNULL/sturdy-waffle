using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace Sturdy.Waffle.Console
{
    internal class Program
    {
        private static async Task Main(string[] args) => await Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                //services.AddHostedService<Something>();
            }).RunConsoleAsync();
    }
}
