namespace ModelGen.Application.Models.Requests;

public record UserUpdateRequest(string FirstName, string MiddleName, string LastName, string Theme, string PictureUrl);