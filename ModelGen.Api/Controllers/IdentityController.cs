using Microsoft.AspNetCore.Mvc;
using ModelGen.Api.Authentication;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(
    IAuthenticationService authenticationService,
    IUserService userService) : ControllerBase
{
    [HttpPost("signin-google")]
    public async Task<ActionResult<UserResponse>> LoginWithGoogle(string token)
    {
        var payload = await authenticationService.ValidateGoogleTokenAsync(token);
        LoginRequest request = new(payload.GivenName, payload.FamilyName, payload.Email, "Dark", payload.Picture);

        var result = await userService.CreateUserAsync(request);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var generatedToken = authenticationService.GenerateToken(request);

        return Ok(generatedToken);
    }
}