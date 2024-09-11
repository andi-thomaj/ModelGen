namespace ModelGen.Domain;

public class BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; }
    public string CreatedBy { get; set; } = String.Empty;
    public DateTimeOffset UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
}