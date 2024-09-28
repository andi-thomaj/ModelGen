using Microsoft.Extensions.DependencyInjection;

namespace ModelGen.Infrastructure.Database;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ModelGenDbContext>();
        if (await dbContext.Database.EnsureCreatedAsync())
        {
            
        }
    }
}