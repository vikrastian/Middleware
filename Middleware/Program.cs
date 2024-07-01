using Middleware.CustomMiddleware;

// creating an instance of builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

// building our app
var app = builder.Build();
// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1: \"Welcome from ASP.NET Core App!\"");
    await next(context);
    await context.Response.WriteAsync("\n\nMiddleware 1: \" I am back at middleware 1\"");
});

// Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\nMiddleware 2: \"I am middleware 2\"\n\n");
    await next(context);
    await context.Response.WriteAsync("Middleware 2: \"I wrote this on my way back, after visiting middleware 3\"");
});

// MIddleware 3 - Using custom middleware class
// app.UseMiddleware<MyMiddleware>();
app.MyMiddleware();

// Middleware 4
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 4: \"This is my first ASP.NET Core APP!\"\n\n");
});

app.Run();
