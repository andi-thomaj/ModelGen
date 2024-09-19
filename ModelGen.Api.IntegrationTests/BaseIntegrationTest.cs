using Microsoft.Extensions.DependencyInjection;
using ModelGen.Application.Contracts.Business;
using ModelGen.Infrastructure.Database;

namespace ModelGen.Api.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    private readonly IServiceScope _scope;

    protected readonly IUserService UserService;
    protected readonly ModelGenDbContext DbContext;
    protected readonly IntegrationTestWebApplicationFactory Factory;
    
    public BaseIntegrationTest(IntegrationTestWebApplicationFactory factory)
    {
        Factory = factory;
        _scope = Factory.Services.CreateScope();

        UserService = _scope.ServiceProvider.GetRequiredService<IUserService>();
        DbContext = _scope.ServiceProvider.GetRequiredService<ModelGenDbContext>();
    }
}