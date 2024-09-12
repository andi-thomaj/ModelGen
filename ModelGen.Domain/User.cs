namespace ModelGen.Domain;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string Middlename { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int LoginAttempts { get; set; }
    public List<Order> Orders { get; set; } = [];
    public List<GeneticData> GeneticDatas { get; set; } = [];
}