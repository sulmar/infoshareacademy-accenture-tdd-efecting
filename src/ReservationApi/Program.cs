var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Ok());

app.MapGet("api/reservations/{id}", (int id) => Results.Ok(id));

app.Run();


