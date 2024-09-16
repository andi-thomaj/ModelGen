using System.Net.Http.Json;
using FluentAssertions;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;
using ModelGen.Shared.Tests.DataGeneration;

namespace ModelGen.Api.IntegrationTests;

public class UserControllerTests : UserControllerTestsBase
{
    [Fact]
    public async Task GetUserByIdApi_ReturnsAUser()
    {
        var webApplicationFactory = GetWebApplicationFactory();
        var generatedUser = TestDataHelper.DataGenerator.GenerateInstance<User>();
        var user = await CreateUserAsync(webApplicationFactory, generatedUser);

        var client = webApplicationFactory.CreateClient();
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