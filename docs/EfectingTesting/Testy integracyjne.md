
## MinimalApi

- Utwórz aplikację webową Api
```
dotnet new web --output Api
```

- Dodaj punkt końcowy `/`
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices();
var app = builder.Build();
app.ConfigureSwagger();
app.UseHttpsRedirection();

app.MapGet("/", ()=> "Hello World!");

app.Run();
```

### Uwidocznienie klasy _Program_

W projekcie typu  _MinimalApi_ klasa `Program` jest niejawnie zdefiniowana dlatego musimy uwidocznić typy wewnętrzne aplikacji internetowej dla projektu testowego.

Można to zrobić na kilka sposobów:

1. Zastosowanie klasy częściowej _(partial class)_ 
   - Dodaj do `Program.cs` linię kodu:
```csharp
public partial class Program { }
```

2. Zastosowanie atrybutu _InternalsVisibleTo_.
- Dodaj do `Program.cs` linię:
```csharp
[assembly: InternalsVisibleTo("MinimalApi.IntegrationTests")]
```

3. Zastosowanie elementu _InternalsVisibleTo_ w konfiguracji projektu.
- Dodaj do pliku projektu SUT (`.csproj`):
```xml
<ItemGroup> 
  <InternalsVisibleTo Include="MinimalApi.IntegrationTests" /> </ItemGroup>
```

## Projekt testowy

- Utwórz projekt testowy
```
dotnet new xunit -o Api.IntegrationTests
```

- Dodaj referencję do projektu SUT _Api_
- Dodaj paczkę
```
dotnet add package Microsoft.AspNetCore.Mvc.Testing
```

- Utwórz test
```csharp
public class HomeTests
    {
        [Fact]
        public async Task Get_WhenCalled_ShouldReturnOk()
        {
            using var factory = new WebApplicationFactory<Api.Program>();
            var client = factory.CreateClient();

            var result = await client.GetAsync(new Uri("", UriKind.Relative));

            Assert.True(result.IsSuccessStatusCode, $"Rzeczywisty kod stanu: {result.StatusCode}");
        }
    }
```


### Wstrzykiwanie fałszywych implementacji
```cs
[Fact]
public async Task Get_WhenCalled_ShouldReturnOk()
{
    // Arrange
    var client = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped<IReservationRepository, FakeReservationRepository>();
            });
        })
        .CreateClient();

    //Act
    var result = await client.GetAsync("/");
    
    // Assert
      var result = await client.GetAsync(new Uri("", UriKind.Relative));

            Assert.True(result.IsSuccessStatusCode, $"Rzeczywisty kod stanu: {result.StatusCode}");
}
```



### Wstrzykiwanie atrap

```
Install-Package Moq
Install-Package Microsoft.AspNetCore.Mvc.Testing
Install-Package Xunit
```

```cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

public class HomeTests
{
    private readonly WebApplicationFactory<Api.Program> _factory;
    private readonly Mock<IReservationRepository> _mockReservationRepository;

    public UnitTest1()
    {
        _mockReservationRepository = new Mock<IReservationRepository>();
        
        // Set up your mock behavior here, e.g., return a specific value when a method is called
        // _mockReservationRepository.Setup(repo => repo.SomeMethod()).Returns(someValue);
    // _mockReservationRepository.Setup(repo => repo.GetReservationAsync(It.IsAny<int>()))
//    .ReturnsAsync(new Reservation { Id = 1, Name = "Test Reservation" });


        _factory = new WebApplicationFactory<PlaygroundApi.Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped(_ => _mockReservationRepository.Object);
                });
            });
    }

    [Fact]
    public async Task Get_WhenCalled_ShouldReturnOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var result = await client.GetAsync(new Uri("", UriKind.Relative));

        // Assert
        Assert.True(result.IsSuccessStatusCode, $"Actual status code: {result.StatusCode}");
    }
}

```