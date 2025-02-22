using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]
public class SecureController : ControllerBase
{
    [HttpGet("data")]
    public IActionResult GetSecureData()
    {
        return Ok("This is secure data");
    }
}
