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

            TripParameters parameters = new TripParameters(from, to, when, numberOfPlaces);

            ITicketService sut = new LegacyTicketService();

            // Act
            var ticket = sut.Buy(parameters);

            // Assert
            Assert.Equal("Bydgoszcz", ticket.RailwayConnection.From);
            Assert.Equal("Warszawa", ticket.RailwayConnection.To);
            Assert.Equal(DateTime.Parse("2022-07-15"), ticket.RailwayConnection.When);
            Assert.Equal(3, ticket.NumberOfPlaces);
        }
    }
}