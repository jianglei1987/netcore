//按照约定中间件
Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
        builder.Configure(app =>
        {
            app.UseMiddleware<StringContentMiddleware>("Hello");
            app.UseMiddleware<StringContentMiddleware>("World!", false);
        }))
    .Build().Run();

sealed class StringContentMiddleware
{
    private readonly string _contents;

    private readonly RequestDelegate _next;

    private readonly bool _forewardToNext;

    public StringContentMiddleware(RequestDelegate next, string contents, bool forewardToNext = true)
    {
        _contents = contents;
        _next = next;
        _forewardToNext = forewardToNext;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync(_contents);
        if (_forewardToNext)
            await _next(context);
    }
}