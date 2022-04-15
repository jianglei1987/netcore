//强类型中间件
Host.CreateDefaultBuilder()
    .ConfigureServices(services =>services.AddSingleton(new StringContentMiddleware("Hello World!")))
    .ConfigureWebHostDefaults(builder =>
        builder.Configure(app =>
        {
            app.UseMiddleware<StringContentMiddleware>();
        }))
    .Build().Run();

sealed class StringContentMiddleware : IMiddleware
{
    private readonly string _content;

    public StringContentMiddleware(string contents) => _content = contents;

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
       return context.Response.WriteAsync(_content);
    }
}