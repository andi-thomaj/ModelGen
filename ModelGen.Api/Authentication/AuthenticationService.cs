using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Apis.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelGen.Api.Configurations;
using ModelGen.Application.Models.Requests;
using ModelGen.Domain;

namespace ModelGen.Api.Authentication;

public class AuthenticationService(IOptions<JwtSettings> jwtSettings) : IAuthenticationService
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;
    
    public string GenerateToken(LoginRequest request)
    {
        var handler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(request),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = credentials,
        };

        var token = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(token);
    }

    public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleTokenAsync(string token)
        => await GoogleJsonWebSignature.ValidateAsync(token);

    private static ClaimsIdentity GenerateClaims(LoginRequest request)
    {
        var claims = new ClaimsIdentity();
        claims.AddClaim(new Claim(ClaimTypes.Name, request.Email));

        return claims;
    }
}