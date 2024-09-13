namespace ModelGen.Domain;

public class Order : BaseEntity
{
    public decimal Amount { get; set; }
    public List<GeneticData> GeneticData { get; set; } = [];
    public Guid UserId { get; set; }
    public User User { get; set; }
}