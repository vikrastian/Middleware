
// creating an instamce of builder
var builder = WebApplication.CreateBuilder(args);

// building our app
var app = builder.Build();

// Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Welcome from ASP.NET Core App!");
    await next(context);
});

// Middleware 2
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This is my first ASP.NET Core APP!");
});

app.Run();
