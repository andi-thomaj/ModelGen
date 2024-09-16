using Google.Apis.Auth;
using ModelGen.Application.Models.Requests;

namespace ModelGen.Api.Authentication;

public interface IAuthenticationService
{
    string GenerateToken(LoginRequest request);
    Task<GoogleJsonWebSignature.Payload> ValidateGoogleTokenAsync(string token);
}