using Microsoft.AspNetCore.Mvc.Testing;

namespace ReserverationApi.Tests;

// dotnet add package Microsoft.AspNetCore.Mvc.Testing
public class HomeTests
{
    [Fact]
    public async Task Home_WhenCalled_ShouldReturnOk()
    {
        // Arrange
        using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        // Act
        var result = await client.GetAsync(new Uri("", UriKind.Relative));

        // Assert
        Assert.True(result.IsSuccessStatusCode, $"Rzeczywisty kod stanu: {result.StatusCode}");
    }
}