using FluentAssertions;
using ModelGen.Application.Models.Requests;
using ModelGen.Application.Models.Responses;
using ModelGen.Domain;
using ModelGen.Shared.Tests.DataGeneration;
using System.Net.Http.Json;

namespace ModelGen.Api.IntegrationTests;

public class UsersControllerTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetById_ShouldReturnUser_WhenUserExists()
    {
        var generatedUser = TestDataHelper.DataGenerator.GenerateInstance<User>();
        var userResult = await UserService.CreateUserAsync(new LoginRequest(generatedUser.FirstName,
            generatedUser.LastName, generatedUser.Email, generatedUser.Theme, generatedUser.PictureUrl));
        var user = userResult.Value;
        var client = Factory.CreateClient();

        var response = await client.GetAsync($"/api/users/{user.Id}");
        var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();

        userResponse.Should().NotBeNull();
        userResponse!.Id.Should().Be(user.Id);
        userResponse.FirstName.Should().Be(user.FirstName);
        userResponse.MiddleName.Should().Be(user.MiddleName);
        userResponse.LastName.Should().Be(user.LastName);
        userResponse.Email.Should().Be(user.Email);
        userResponse.PictureUrl.Should().Be(user.PictureUrl);
    }

    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        var generatedUser = TestDataHelper.DataGenerator.GenerateInstance<User>();
        var userResult = await UserService.CreateUserAsync(new LoginRequest(generatedUser.FirstName,
            generatedUser.LastName, generatedUser.Email, generatedUser.Theme, generatedUser.PictureUrl));
        var user = userResult.Value;
        var client = Factory.CreateClient();

        var response = await client.GetAsync($"/api/users?email={generatedUser.Email}");
        var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();

        userResponse.Should().NotBeNull();
        userResponse!.Id.Should().Be(user.Id);
        userResponse.FirstName.Should().Be(user.FirstName);
        userResponse.MiddleName.Should().Be(user.MiddleName);
        userResponse.LastName.Should().Be(user.LastName);
        userResponse.Email.Should().Be(user.Email);
        userResponse.PictureUrl.Should().Be(user.PictureUrl);
    }

    [Fact]
    public async Task UpdateUser_ShouldReturnUser_UpdatedSuccessfully()
    {
        var generatedUser = TestDataHelper.DataGenerator.GenerateInstance<User>();
        var userCreatedResult = await UserService.CreateUserAsync(new LoginRequest(generatedUser.FirstName,
            generatedUser.LastName, generatedUser.Email, generatedUser.Theme, generatedUser.PictureUrl));
        var userCreated = userCreatedResult.Value;
        var updatedTheme = "black";
        var userResult = await UserService.UpdateUserAsync(userCreated.Id, new UserUpdateRequest(userCreated.FirstName, userCreated.MiddleName, userCreated.LastName, updatedTheme, userCreated.PictureUrl));
        var user = userResult.Value;
        var client = Factory.CreateClient();
        var request =
            new UserUpdateRequest(user.FirstName, user.MiddleName, user.LastName, updatedTheme, user.PictureUrl);

        var response = await client.PutAsJsonAsync($"/api/users/{user.Id}", request);
        var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();

        userResponse.Should().NotBeNull();
        userResponse!.Id.Should().Be(user.Id);
        userResponse.FirstName.Should().Be(user.FirstName);
        userResponse.MiddleName.Should().Be(user.MiddleName);
        userResponse.LastName.Should().Be(user.LastName);
        userResponse.Email.Should().Be(user.Email);
        userResponse.Theme.Should().Be(user.Theme);
        userResponse.PictureUrl.Should().Be(user.PictureUrl);
    }
}