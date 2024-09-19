namespace ModelGen.Application.Models.Responses;

public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Theme { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}