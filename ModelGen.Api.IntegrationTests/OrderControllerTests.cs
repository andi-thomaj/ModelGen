using System.Net.Http.Json;

namespace ModelGen.Api.IntegrationTests;

public class OrderControllerTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetOrder()
    {
        var application = new IntegrationTestWebApplicationFactory();
        
        
        
        var client = application.CreateClient();
        
        var response = await client.GetAsync("/api/order");
        
        response.EnsureSuccessStatusCode();

        //var deserializedResponse = await response.Content.ReadFromJsonAsync();
        //deserializedResponse.Id.Should().NotBeEmpty();
    }
}