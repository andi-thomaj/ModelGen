namespace ModelGen.Application.Models.Requests;

public record LoginRequest(string FirstName, string LastName, string Email, string Theme, string PictureUrl);