using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosting_DependencyInjection
{
    public sealed class PerformanceMetricsCollector : IHostedService
    {
        private readonly IProcessorMetricsCollector _metricsCollector;
        private readonly IMemoryMetricsCollector _memoryMetricsCollector;
        private readonly INetworkMetricsCollector _networkMetricsCollector;
        private IDisposable _scheduler;

        public PerformanceMetricsCollector(
                IProcessorMetricsCollector metricsCollector,
                IMemoryMetricsCollector memoryMetricsCollector,
                INetworkMetricsCollector networkMetricsCollector
            )
        {
            _metricsCollector = metricsCollector;
            _memoryMetricsCollector = memoryMetricsCollector;
            _networkMetricsCollector = networkMetricsCollector;
        }
        
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
            static void Callback(object data)
            {
                Console.WriteLine($"[{DateTimeOffset.Now}]{PerformanceMetrics.Create()}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler.Dispose();
            return Task.CompletedTask;
        }
    }
}
