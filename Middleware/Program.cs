
// creating an instamce of builder
var builder = WebApplication.CreateBuilder(args);

// building our app
var app = builder.Build();

// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("MIddleware 1: \"Welcome from ASP.NET Core App!\"");
    await next(context);
});

// Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("\n\nMiddleware 2: \"I am middleware 2\"\n\n");
    await next(context);
    await context.Response.WriteAsync("\n\nMiddleware 2: \"I wrote this on my way back, after visiting middleware 3\"");
});

// Middleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Middleware 3: \"This is my first ASP.NET Core APP!\"");
});

app.Run();
