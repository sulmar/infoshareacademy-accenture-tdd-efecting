using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ReservationApi;
using ReservationApi.Abstractions;
using ReservationApi.Infrastructure;
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
                    services.RemoveAll(typeof(DbContextOptions<ApplicationDbContext>));

                    services.AddScoped<IReservationRepository, DbReservationRepository>();

                    var configuration = new ConfigurationBuilder()
                    .AddUserSecrets<ReservationTests>()
                    .Build();

                    string connectionString = configuration.GetConnectionString("DbReservation");

                    services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(connectionString));

                    var serviceProvider = services.BuildServiceProvider();
                    var scope = serviceProvider.CreateScope();
                    var db = scope.ServiceProvider.GetService<ApplicationDbContext>();

                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    db.Reservations.Add(new Reservation { Place = "a" });
                    db.SaveChanges();

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