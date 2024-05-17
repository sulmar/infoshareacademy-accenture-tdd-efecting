using Microsoft.EntityFrameworkCore;
using ReservationApi.Abstractions;
using ReservationApi.Model;

namespace ReservationApi.Infrastructure;

// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
public class DbReservationRepository(ApplicationDbContext db) : IReservationRepository
{
    public async Task<Reservation> GetReservationAsync(int id)
    {
        return await db.Reservations.FindAsync(id);
    }
}


public class ApplicationDbContext : DbContext
{
    public DbSet<Reservation> Reservations { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}