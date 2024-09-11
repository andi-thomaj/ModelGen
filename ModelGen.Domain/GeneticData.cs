namespace ModelGen.Domain;

public class GeneticData : BaseEntity
{
    public byte[] RawData { get; set; } = [];
    public string G25Coordinates { get; set; } = string.Empty;
}