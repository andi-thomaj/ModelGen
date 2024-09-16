using System.Net.Http.Json;
using ModelGen.Application.Models.Responses;

namespace ModelGen.Api.IntegrationTests;

public class UserControllerTests : UserControllerTestsBase
{
    [Fact]
    public async Task GetUserByIdReturnsAUser()
    {
        var application = new ModelGenWebApplicationFactory();
        
        var client = application.CreateClient();
        
        var response = await client.GetAsync($"/api/user/{Guid.NewGuid()}");
        
        response.EnsureSuccessStatusCode();

        var userResponse = await response.Content.ReadFromJsonAsync<UserResponse>();
        //deserializedResponse.Id.Should().NotBeEmpty();
    }
}