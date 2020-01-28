using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Sturdy.Waffle.Shared.Interfaces;

namespace Sturdy.Waffle.Shared.Workers
{
    public class HammerWorker : IBackgroundService
    {
        private Task _executingTask;
        
        private readonly CancellationTokenSource _stoppingCts = new CancellationTokenSource();
        private readonly ILogger<HammerWorker> _logger;

        public HammerWorker(ILogger<HammerWorker> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new System.NotImplementedException();
        }
    }
}