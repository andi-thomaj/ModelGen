namespace ModelGen.Domain;

public class GeneticData : BaseEntity
{
    public byte[] RawData { get; set; } = [];
    public string G25Coordinates { get; set; } = string.Empty;
    public string PaternalHaplogroup { get; set; } = string.Empty;
    public string MaternalHaplogroup { get; set; } = string.Empty;
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
    public List<User> Users { get; set; } = [];
}