using Google.Apis.Auth;
using ModelGen.Domain;

namespace ModelGen.Api.Authentication;

public interface IAuthenticationService
{
    string GenerateToken(User user);
    Task<GoogleJsonWebSignature.Payload> ValidateGoogleTokenAsync(string token);
}