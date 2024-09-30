namespace ModelGen.Application.Models.Responses;

public record UserResponse(
    Guid Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Theme,
    string PictureUrl,
    string GoogleIdToken,
    string Jwt,
    string JwtRefresh,
    int LoginAttempts,
    bool IsBlocked,
    bool IsDeleted);