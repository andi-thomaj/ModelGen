namespace ModelGen.Domain;

public class GeneticData : BaseEntity
{
    public byte[] RawData { get; set; } = [];
    public string RawDataFileName { get; set; } = string.Empty;
    public DateTimeOffset UploadedAt { get; set; }
    public string G25Coordinates { get; set; } = string.Empty;
    public string PaternalHaplogroup { get; set; } = string.Empty;
    public string MaternalHaplogroup { get; set; } = string.Empty;
    public Guid? OrderId { get; set; }
    public Order? Order { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}