using System.Net.Http.Json;
using FluentAssertions;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;
using ModelGen.Shared.Tests.DataGeneration;

namespace ModelGen.Api.IntegrationTests;

public class UserControllerTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetUserByIdApi_ReturnsAUser()
    {
        var generatedUser = TestDataHelper.DataGenerator.GenerateInstance<User>();
        var userResult = await UserService.CreateUserAsync(new LoginRequest(generatedUser.FirstName,
            generatedUser.LastName, generatedUser.Email, generatedUser.Theme, generatedUser.PictureUrl));
        var user = userResult.Value;

        var client = Factory.CreateClient();
        var response = await client.GetAsync($"/api/user/{user.Id}");
        var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();
        
        userResponse.Should().NotBeNull();
        userResponse!.Id.Should().Be(user.Id);
        userResponse.FirstName.Should().Be(user.FirstName);
        userResponse.MiddleName.Should().Be(user.MiddleName);
        userResponse.LastName.Should().Be(user.LastName);
        userResponse.Email.Should().Be(user.Email);
        userResponse.PictureUrl.Should().Be(user.PictureUrl);
    }
}