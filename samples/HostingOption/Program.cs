// See https://aka.ms/new-console-template for more information
using Hosting_DependencyInjection;
using HostingOption;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");
var collector = new FakeMetricsCollector();

new HostBuilder()
    .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
                .ConfigureServices(services => services
                .AddSingleton<IProcessorMetricsCollector>(collector)
                .AddSingleton<IMemoryMetricsCollector>(collector)
                .AddSingleton<INetworkMetricsCollector>(collector)
                .AddSingleton<IMetricsDeliverer, FakeMetricsDeliverer>()
                .AddSingleton<IHostedService, PerformanceMetricsCollector>()
                .AddOptions()
                .Configure<MetricsCollectionOptions>((MetricsCollectionOptions options) =>
                {
                    options.CaptureInterval = TimeSpan.FromSeconds(1);
                    options.Endpoint = new Endpoint() { Host = "192.168.1.1", Port = 2345 };
                    options.TransportType = TransportType.Tcp;
                })
                ).Build().Run();