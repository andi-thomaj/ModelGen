namespace ModelGen.Application.Models.Requests;

public class UserUpdateRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Theme { get; set; }  = string.Empty;
}