# 承载系统(Hosting)

借助.NET Core 提供的承载(Hosting)系统，我们可以将任意一个或者多个长时间运行(Long-Running)的服务寄宿或者承载于托管进程中。ASP.NET Core 应用仅仅是该承载系统的一种典型的服务类型，任何需要在后台长时间运行的操作都可以定义成标准化的服务并利用该系统来承载。

# 集成接口IHostedService
+ Nuget包 Microsoft.Extensions.Hosting
+ 接口源码
```C# 
namespace Microsoft.Extensions.Hosting
{
    //
    // 摘要:
    //     Defines methods for objects that are managed by the host.
    public interface IHostedService
    {
        //
        // 摘要:
        //     Triggered when the application host is ready to start the service.
        //
        // 参数:
        //   cancellationToken:
        //     Indicates that the start process has been aborted.
        Task StartAsync(CancellationToken cancellationToken);

        //
        // 摘要:
        //     Triggered when the application host is performing a graceful shutdown.
        //
        // 参数:
        //   cancellationToken:
        //     Indicates that the shutdown process should no longer be graceful.
        Task StopAsync(CancellationToken cancellationToken);
    }
}
```