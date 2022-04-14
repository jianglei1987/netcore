using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hosting_DependencyInjection
{
    public class FakeMetricsCollector : IProcessorMetricsCollector, IMemoryMetricsCollector, INetworkMetricsCollector
    {
        long INetworkMetricsCollector.GetThroughput()
        {
            return PerformanceMetrics.Create().Network;
        }

        long IProcessorMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Processor;
        }

        long IMemoryMetricsCollector.GetUsage()
        {
            return PerformanceMetrics.Create().Memory;
        }
    }
}
