using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.ChangeTracking;
using ModelGen.Domain;

namespace ModelGen.Infrastructure.Database;

public class ModelGenDbContext(DbContextOptions<ModelGenDbContext> options) : DbContext(options)
{
    public DbSet<GeneticData> GeneticData { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModelGenDbContext).Assembly);
    }
}