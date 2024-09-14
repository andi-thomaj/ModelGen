using Microsoft.AspNetCore.Mvc;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("signin-google")]
    public async Task<ActionResult> LoginWithGoogle(string token)
    {
        return Ok(token);
    }
}