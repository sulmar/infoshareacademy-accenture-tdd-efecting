using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ReserverationApi.Tests")]


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Ok());

app.Run();


