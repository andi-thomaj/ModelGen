using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelGen.Api.Authentication;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Shared;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(
    IAuthenticationService authenticationService,
    IUserService userService) : ControllerBase
{
    [HttpPost("signin-google")]
    public async Task<ActionResult<UserResponse>> LoginWithGoogle([FromBody] LoginWithGoogleRequest request)
    {
        var payload = await authenticationService.ValidateGoogleTokenAsync(request.Token);
        LoginRequest loginRequest = new(payload.GivenName, payload.FamilyName, payload.Email, "Dark", payload.Picture);

        var result = await userService.CreateUserAsync(loginRequest);

        if (result.IsFailure && result.Error.Type != ErrorType.Conflict)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);
    }
}