using ReservationApi.Model;

namespace ReservationApi.Abstractions;

public interface IReservationRepository
{
    Task<Reservation> GetReservationAsync(int id);
}


