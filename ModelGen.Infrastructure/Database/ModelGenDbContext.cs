using Microsoft.EntityFrameworkCore;

namespace ModelGen.Infrastructure.Database;

public class ModelGenDbContext(DbContextOptions<ModelGenDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelGenDbContext).Assembly);
    }
}