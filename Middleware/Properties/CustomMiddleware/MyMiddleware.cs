using System.Net.NetworkInformation;

namespace Middleware.CustomMiddleware
{

    // Custom Middleware Class
    public class MyMiddleware: IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Before logic
            await context.Response.WriteAsync("Middleware 3: Custom middleware started!\n\n");

            await next(context);

            // After logic
            await context.Response.WriteAsync("Middleware 3: Custom middleware finished\n\n");
        }
    }

    // Custom middleware Extension - gjør det enklere å rbuke en custom extension
    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();        
        }

    }
}


// We could/should give our middleware names according to what they ar going to do.
// We have registered this middleware class in program.cs file for it to work.