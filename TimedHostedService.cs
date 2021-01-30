using CovidData.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CovidData
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private BackgroundWorker _worker;

        private readonly IServiceScopeFactory _scopeFactory;
        private IServiceScope _scope;

        public TimedHostedService(IServiceScopeFactory scopeFactory) {
            _scopeFactory = scopeFactory;
            _scope = _scopeFactory.CreateScope();
        } 

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _worker = new BackgroundWorker(_scope.ServiceProvider.GetRequiredService<CovidDbContext>());
            _worker.DoWork();
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
