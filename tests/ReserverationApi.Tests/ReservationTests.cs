using Microsoft.AspNetCore.Mvc.Testing;

namespace ReserverationApi.Tests;

public class ReservationTests
{
    [Fact]
    public async Task GetById_WhenIdIsValid_ShouldReturnReservationWithId()
    {
        // Arrange
        using var factory = new WebApplicationFactory<Program>();
        var client = factory.CreateClient();

        int reservationId = 1;

        // Act
        var response = await client.GetAsync($"api/reservations/{reservationId}");
        var result = await response.Content.ReadAsStringAsync();

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal("1", result);


    }
}