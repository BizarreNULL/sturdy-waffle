using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

namespace Sturdy.Waffle.Shared.Interfaces
{
    public interface IBackgroundService : IHostedService, IDisposable
    {
        Task ExecuteAsync(CancellationToken stoppingToken);
    }
}