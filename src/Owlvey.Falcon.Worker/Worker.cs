// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Owlvey.Falcon.Components;

namespace Owlvey.Falcon.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConfigurationComponent _configuration;
        private Timer _timer;

        public Worker(ILogger<Worker> logger, ConfigurationComponent configuration)
        {
            this._configuration = configuration;
            _logger = logger;
        }
        public override void Dispose()
        {
            base.Dispose();
            this._timer?.Dispose();
        }
        /*
        public override Task StartAsync(CancellationToken cancellationToken)
        {

            Console.WriteLine("start worker");

            this._timer = new Timer(Dowork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        public void Dowork(object state) {
            Console.WriteLine("do work at " + DateTime.Now.ToLongTimeString());
        }

       

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("stop worker");
            return Task.CompletedTask;

        }
        */
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {            
            
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            _logger.LogInformation("Worker identity at: {0}", this._configuration.OwlveyIdentity  );
            _logger.LogInformation("Worker api at: {0}", this._configuration.OwlveyApi);
            _logger.LogInformation("Worker client id at: {0}", this._configuration.OwlveyClientId);
            _logger.LogInformation("Worker secret key at: {0}", this._configuration.OwlveySecretKey);
            return;
        }

    }
}
