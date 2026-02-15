using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduPlatform.API.Filters;

public class ApiResponseFilter : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
        // ↑ Response gönderilmeden ÖNCE
    {
        if (context.Result is ObjectResult objectResult)
        {
            var isSuccess = objectResult.StatusCode is null or >= 200 and < 300;

            objectResult.Value = new
            {
                success = isSuccess,
                data = objectResult.Value,
                timestamp = DateTime.UtcNow
            };
        }
    }

    public void OnResultExecuted(ResultExecutedContext context)
        // ↑ Response gönderildikten SONRA
    {
        // loglama, cleanup vs.
    }
}
