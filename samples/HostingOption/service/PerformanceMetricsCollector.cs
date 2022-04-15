using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingOption
{
    public sealed class PerformanceMetricsCollector : IHostedService
    {

        private readonly IProcessorMetricsCollector _processorMetricsCollector;
        private readonly IMemoryMetricsCollector _memoryMetricsCollector;
        private readonly INetworkMetricsCollector _networkMetricsCollector;
        private readonly IMetricsDeliverer _metricsDeliverer;
        private readonly TimeSpan _timeSpan;
        private IDisposable _scheduler;

        public PerformanceMetricsCollector(
                IProcessorMetricsCollector processorMetricsCollector,
                IMemoryMetricsCollector memoryMetricsCollector,
                INetworkMetricsCollector networkMetricsCollector,
                IMetricsDeliverer metricsDeliverer,
                IOptions<MetricsCollectionOptions> optionAccessor
            )
        {
            _processorMetricsCollector = processorMetricsCollector;
            _memoryMetricsCollector = memoryMetricsCollector;
            _networkMetricsCollector = networkMetricsCollector;
            _metricsDeliverer = metricsDeliverer;
            _timeSpan = optionAccessor.Value.CaptureInterval;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = new Timer(Callback, null, TimeSpan.FromSeconds(5), _timeSpan);
            return Task.CompletedTask;
            async void Callback(object data)
            {
                var counter = new PerformanceMetrics
                {
                    Processor = _processorMetricsCollector.GetUsage(),
                    Memory = _memoryMetricsCollector.GetUsage(),
                    Network = _networkMetricsCollector.GetThroughput(),
                };
              await _metricsDeliverer.DeliverAsync(counter);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _scheduler.Dispose();
            return Task.CompletedTask;
        }
    }
}
