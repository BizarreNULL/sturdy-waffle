using Microsoft.Extensions.Hosting;

namespace Sturdy.Waffle.Console
{
    internal class Program
    {
        private static void Main(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                //services.AddHostedService<Something>();
            });
    }
}
