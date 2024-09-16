using Microsoft.Extensions.DependencyInjection;
using ModelGen.Application.Contracts.Business;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;

namespace ModelGen.Api.IntegrationTests;

public class UserControllerTestsBase
{
    protected ModelGenWebApplicationFactory GetWebApplicationFactory() => new();

    protected static async Task<UserResponse> CreateUserAsync(ModelGenWebApplicationFactory webApplicationFactory, User user)
    {
        using var scope = webApplicationFactory.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var userService = serviceProvider.GetRequiredService<IUserService>();
        var userResult = await userService.CreateUserAsync(new LoginRequest(user.FirstName,
            user.LastName, user.Email, user.Theme, user.PictureUrl));
        
        return userResult.Value;
    }
}