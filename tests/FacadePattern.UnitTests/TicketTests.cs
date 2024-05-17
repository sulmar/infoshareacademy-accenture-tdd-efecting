using FacadePattern.Models;
using FacadePattern.Repositories;
using FacadePattern.Services;

namespace FacadePattern.UnitTests
{
    public class TicketTests
    {
        [Fact]
        public void BuyTicket()
        {
            // Arrange
            string from = "Bydgoszcz";
            string to = "Warszawa";
            DateTime when = DateTime.Parse("2022-07-15");
            byte numberOfPlaces = 3;

            RailwayConnectionRepository railwayConnectionRepository = new RailwayConnectionRepository();
            TicketCalculator ticketCalculator = new TicketCalculator();
            ReservationService reservationService = new ReservationService();
            PaymentService paymentService = new PaymentService();
            EmailService emailService = new EmailService();

            // Act
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(from, to, when);
            decimal price = ticketCalculator.Calculate(railwayConnection, numberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, numberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            // Assert
            Assert.Equal("Bydgoszcz", ticket.RailwayConnection.From);
            Assert.Equal("Warszawa", ticket.RailwayConnection.To);
            Assert.Equal(DateTime.Parse("2022-07-15"), ticket.RailwayConnection.When);
            Assert.Equal(3, ticket.NumberOfPlaces);
        }
    }
}