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
            _logger.LogDebug($"{nameof(HammerWorker)} started");
            _executingTask = ExecuteAsync(_stoppingCts.Token);
            
            return _executingTask.IsCompleted ? _executingTask : Task.CompletedTask; 
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_executingTask == null)
                return;

            try
            {
                _logger.LogInformation($"{nameof(HammerWorker)} stopping");
                _stoppingCts.Cancel();
            }
            finally
            {
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.Infinite, cancellationToken));
            }
        }

        public void Dispose()
        {
            _stoppingCts.Cancel();
        }
        
        public Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"{nameof(HammerWorker)} execution started");
            _executingTask = ExecuteAsync(_stoppingCts.Token);

            return _executingTask.IsCompleted ? _executingTask : Task.CompletedTask;
        }
    }
}