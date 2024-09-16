using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModelGen.Infrastructure.Database;

namespace ModelGen.Api.IntegrationTests;

public class ModelGenWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<ModelGenDbContext>));
            
            var connectionString = GetConnectionString();
            services.AddDbContext<ModelGenDbContext>(options => options.UseNpgsql(connectionString));
            
            // Add the authentication handler
            services.AddAuthentication(defaultScheme: "TestScheme")
                .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
                    "TestScheme", options => { });
            
            var dbContext = CreateDbContext(services);
            dbContext.Database.EnsureDeleted();
            
        });
    }

    private static string? GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<ModelGenWebApplicationFactory>()
            .Build();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        return connectionString;
    }

    private static ModelGenDbContext CreateDbContext(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ModelGenDbContext>();
        return dbContext;
    }
}