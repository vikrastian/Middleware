﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.Properties.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnotherCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AnotherCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            httpContext.Response.WriteAsync("AnotherMiddleware called (template created)");
            await _next(httpContext);
            httpContext.Response.WriteAsync("AnotherMiddleware called for the second time(template created)");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnotherCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnotherCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnotherCustomMiddleware>();
        }
    }
}
