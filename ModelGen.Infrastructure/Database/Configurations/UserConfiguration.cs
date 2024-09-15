using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelGen.Domain;

namespace ModelGen.Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(x => x.MiddleName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder
            .Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder
            .Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasMany(x => x.Orders)
            .WithOne(x => x.User);
        
        builder
            .HasMany(x => x.GeneticData)
            .WithMany(x => x.Users)
            .UsingEntity(x => x.ToTable("GeneticDataUsers"));
    }
}