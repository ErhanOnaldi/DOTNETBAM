using Microsoft.AspNetCore.Mvc;

namespace EduPlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]   
    public IActionResult Check()
    {
        
        return Ok(new   
        {
            status = "healthy",
            timestamp = DateTime.UtcNow,
            version = "1.0.0"
        });
    }
}