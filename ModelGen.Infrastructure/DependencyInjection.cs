using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Contracts.Persistence;
using ModelGen.Infrastructure.Database;
using ModelGen.Infrastructure.Repositories;
using ModelGen.Infrastructure.Services;
using ModelGen.Shared;

namespace ModelGen.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDatabase(configuration)
            .AddServicesAndRepositories();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        Ensure.NotNullOrEmpty(connectionString);

        services.AddDbContext<ModelGenDbContext>(options => options.UseNpgsql(connectionString));

        return services;
    }

    private static IServiceCollection AddServicesAndRepositories(this IServiceCollection services)
    {
        services.AddTransient<IGeneticDataService, GeneticDataService>();
        services.AddTransient<IGeneticDataRepository, GeneticDataRepository>();

        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IOrderRepository, OrderRepository>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }
}