using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Owlvey.Falcon.Components;

namespace Owlvey.Falcon.Worker
{
    public class ServiceLeadersWorker : BackgroundService
    {
        private readonly ILogger<ServiceLeadersWorker> _logger;

        public ServiceLeadersWorker(ILogger<ServiceLeadersWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Service Leader running at: {time}", DateTimeOffset.Now);
                try
                {
                    var owlvey = new ShellComponent();
                    await owlvey.NotifyAvailabilityServiceLeaders(DateTime.Now);
                    _logger.LogInformation("Service Leader ends at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Exception on Service Leader Notificaiton");
                }
                
                await Task.Delay(12 * 60 * 60 * 1000, stoppingToken);
            }
        }
    }
}
