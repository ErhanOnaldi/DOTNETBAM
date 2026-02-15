namespace EduPlatform.API.Middlewares;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    public RequestTimingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        await _next(context);
        stopwatch.Stop();
        Console.WriteLine($"Request Time : {stopwatch.ElapsedMilliseconds} ms");
    }
}