using Microsoft.AspNetCore.Mvc;
using ModelGen.Api.Authentication;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Requests;
using ModelGen.Domain;

namespace ModelGen.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController(IAuthenticationService authenticationService,
    IUserService userService) : ControllerBase
{
    [HttpPost("signin-google")]
    public async Task<ActionResult> LoginWithGoogle(string token)
    {
        var payload = await authenticationService.ValidateGoogleTokenAsync(token);
        LoginRequest request = new()
        {
            Email = payload.Email,
            FirstName = payload.GivenName,
            LastName = payload.FamilyName,
            PictureUrl = payload.Picture,
        };
        
        var result = await userService.CreateUserAsync(request);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var generatedToken = authenticationService.GenerateToken(request);
        
        return Ok(generatedToken);
    }
}