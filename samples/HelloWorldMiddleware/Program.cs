//简单的中间件定义
Func<RequestDelegate, RequestDelegate> Middleware3 = (RequestDelegate next)=>
{
    return next;
};

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.Use(Middleware1);
            app.Use(Middleware2);
            app.Use(Middleware3);
            app.Run(async (context) => { await context.Response.WriteAsync("!"); });
        });
    })
    .Build().Run();

static RequestDelegate Middleware1(RequestDelegate next)
    => async context =>
    {
        await context.Response.WriteAsync("Hello");
        await next(context);
    };

static RequestDelegate Middleware2(RequestDelegate next)
    => async context =>
    {
        await context.Response.WriteAsync("World");
        await next(context);
    };
