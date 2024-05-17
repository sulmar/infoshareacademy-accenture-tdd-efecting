using ReservationApi;
using ReservationApi.Abstractions;
using ReservationApi.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IReservationRepository, NullReservationRepository>();
var app = builder.Build();

app.MapGet("/", () => Results.Ok());

app.MapGet("api/reservations/{id}", async (int id, IReservationRepository repository) => 
{
    var reservation = await repository.GetReservationAsync(id);

    var response = new ReservationResponse(reservation.ReservationId, reservation.Place);

    return Results.Ok(response);
});

app.Run();

// Null Object Pattern
internal class NullReservationRepository : IReservationRepository
{
    public Task<Reservation> GetReservationAsync(int id)
    {
        return Task.FromResult(new Reservation());
    }
}
