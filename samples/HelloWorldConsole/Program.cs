// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

Host.CreateDefaultBuilder()
    .ConfigureWebHostDefaults(builder =>
        builder.Configure(app =>
        {
            app.Run(async context =>
             {
                 await context.Response.WriteAsync("Hello World");
             });
        }))
    .Build().Run();
