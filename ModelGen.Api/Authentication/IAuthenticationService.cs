using Google.Apis.Auth;

namespace ModelGen.Api.Authentication;

public interface IAuthenticationService
{
    string GenerateToken(string email);
    Task<GoogleJsonWebSignature.Payload> ValidateGoogleTokenAsync(string token);
}