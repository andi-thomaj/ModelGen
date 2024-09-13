using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelGen.Domain;

namespace ModelGen.Infrastructure.Database.Configurations;

internal sealed class GeneticDataConfiguration : IEntityTypeConfiguration<GeneticData>
{
    public void Configure(EntityTypeBuilder<GeneticData> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.RawData)
            .IsRequired();

        builder
            .Property(x => x.G25Coordinates)
            .IsRequired();

        builder
            .Property(x => x.PaternalHaplogroup)
            .IsRequired();

        builder
            .Property(x => x.MaternalHaplogroup)
            .IsRequired();
    }
}