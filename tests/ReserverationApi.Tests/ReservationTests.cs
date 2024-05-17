using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ReservationApi;
using ReservationApi.Abstractions;
using ReservationApi.Model;
using System.Net.Http.Json;

namespace ReserverationApi.Tests;

public class FakeReservationRepository : IReservationRepository
{
    public Task<Reservation> GetReservationAsync(int id) => Task.FromResult(new Reservation { ReservationId = id, Place = "a" });
}

public class ReservationTests
{
    [Fact]
    public async Task GetById_WhenIdIsValid_ShouldReturnReservationWithId()
    {
        // Arrange
        using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IReservationRepository, FakeReservationRepository>();
                });
            });
        var client = factory.CreateClient();

        int reservationId = 1;

        // Act
        var response = await client.GetAsync($"api/reservations/{reservationId}");
        var result = await response.Content.ReadFromJsonAsync<ReservationResponse>();

        // Assert
        Assert.True(response.IsSuccessStatusCode);
        Assert.Equal(1, result.Id);
        Assert.Equal("a", result.Place);
    }
}