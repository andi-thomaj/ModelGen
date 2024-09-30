namespace ModelGen.Domain;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int LoginAttempts { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsDeleted { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
    public string GoogleIdToken { get; set; } = string.Empty;
    public string Jwt { get; set; } = string.Empty;
    public string JwtRefresh { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = [];
    public List<GeneticData> GeneticData { get; set; } = [];
    public string Theme { get; set; } = string.Empty;
}