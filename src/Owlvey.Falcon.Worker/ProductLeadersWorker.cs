using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Owlvey.Falcon.Components;

namespace Owlvey.Falcon.Worker
{
    public class ProductLeadersWorker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public ProductLeadersWorker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Product Leader running at: {time}", DateTimeOffset.Now);
                try
                {
                    var owlvey = new ShellComponent();
                    await owlvey.NotifyAvailablityProductLeaders(DateTime.Now);
                    _logger.LogInformation("Product Leader ends at: {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    this._logger.LogError(ex, "Exception on Product Leader Notificaiton");
                }                
                await Task.Delay(12 * 60 * 60 * 1000, stoppingToken);
            }
        }
    }
}
