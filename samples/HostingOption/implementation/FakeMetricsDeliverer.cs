using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingOption
{
    public class FakeMetricsDeliverer : IMetricsDeliverer
    {
        private readonly TransportType _transportType;

        private readonly Endpoint _endpoint;

        public FakeMetricsDeliverer(IOptions<MetricsCollectionOptions> options)
        {
            _transportType = options.Value.TransportType;
            _endpoint = options.Value.Endpoint;
        }

        public Task DeliverAsync(PerformanceMetrics counter)
        {
            Console.WriteLine($"[{DateTimeOffset.Now}] Deliver performance counter {counter} to {_endpoint} via {_transportType}");
            return Task.CompletedTask;
        }
    }
}
