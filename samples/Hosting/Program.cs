// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

//依赖注入方法
new HostBuilder().ConfigureServices(services =>services.AddSingleton<IHostedService,PerformanceMetricsCollector>()).Build().Run();


//针对IHostedServce服务注册还可以调用IServiceCollection接口的AddHostedService<THostedService>扩展方法完成。
//new HostBuilder().ConfigureServices(services =>
//                                services.AddHostedService<PerformanceMetricsCollector>())
//    .Build()
//    .Run();
