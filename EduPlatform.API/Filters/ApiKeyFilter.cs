using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduPlatform.API.Filters;

public class ApiKeyFilter : IActionFilter
{
    private const string ApiKeyHeader = "X-Api-Key";
    private readonly IConfiguration _configuration;

    public ApiKeyFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnActionExecuting(ActionExecutingContext context)
        // ↑ Action çalışmadan ÖNCE
    {
        var hasApiKey = context.HttpContext.Request.Headers
            .TryGetValue(ApiKeyHeader, out var apiKey);

        if (!hasApiKey || apiKey != _configuration.GetValue<string>("ApiSettings:ApiKey"))
        {
            context.Result = new UnauthorizedObjectResult(new
            {
                error = "Invalid or missing API key."
            });
            // context.Result set edilince action ÇALIŞMAZ, direkt response döner
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
        // ↑ Action çalıştıktan SONRA
    {
        // şimdilik boş
    }
}