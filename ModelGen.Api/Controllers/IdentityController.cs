using Microsoft.AspNetCore.Mvc;
using ModelGen.Api.Authentication;
using ModelGen.Application.Contracts.Business;
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
        User user = new()
        {
            Email = payload.Email,
            FirstName = payload.GivenName,
            LastName = payload.FamilyName,
            GooglePictureUrl = payload.Picture,
            IsGoogleAuthenticated = true
        };
        
        var result = await userService.CreateUserAsync(user);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        var generatedToken = authenticationService.GenerateToken(user);
        
        return Ok(generatedToken);
    }
}