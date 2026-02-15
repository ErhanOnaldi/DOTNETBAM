using EduPlatform.API.Middlewares;

namespace EduPlatform.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseMiddleware<GlobalExceptionMiddleware>();  
        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<RequestTimingMiddleware>();
        return app;
    }
}