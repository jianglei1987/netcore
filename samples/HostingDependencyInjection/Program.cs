// See https://aka.ms/new-console-template for more information
using Hosting_DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

var collector = new FakeMetricsCollector();

new HostBuilder().ConfigureServices(services => services
                .AddSingleton<IProcessorMetricsCollector>(collector)
                .AddSingleton<IMemoryMetricsCollector>(collector)
                .AddSingleton<INetworkMetricsCollector>(collector)
                .AddSingleton<IHostedService, PerformanceMetricsCollector>()
                ).Build().Run();