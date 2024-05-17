using FacadePattern.Models;
using FacadePattern.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Services
{
    public class TripParameters
    {
        public TripParameters(string from, string to, DateTime when, byte numberOfPlaces)
        {
            From = from;
            To = to;
            When = when;
            NumberOfPlaces = numberOfPlaces;
        }

        public string From { get; set; }
        public string To { get; set; }

        public DateTime When { get; set; }
        public byte NumberOfPlaces { get; set; } = 1;
    }


    public interface ITicketService
    {
        Ticket Buy(TripParameters parameters);
    }


    public class MyTicketService : ITicketService
    {
        public Ticket Buy(TripParameters parameters)
        {
            return new Ticket {  Price = 10, NumberOfPlaces =3 , RailwayConnection = new RailwayConnection() };
        }
    }

    public class LegacyTicketService : ITicketService
    {
        private RailwayConnectionRepository railwayConnectionRepository;
        private TicketCalculator ticketCalculator;
        private ReservationService reservationService;
        private PaymentService paymentService;
        private EmailService emailService;

        public LegacyTicketService()
        {
            railwayConnectionRepository = new RailwayConnectionRepository();
            ticketCalculator = new TicketCalculator();
            reservationService = new ReservationService();
            paymentService = new PaymentService();
            emailService = new EmailService();
        }


        public Ticket Buy(TripParameters parameters)
        {

            RailwayConnection railwayConnection = railwayConnectionRepository.Find(parameters.From, parameters.To, parameters.When);
            decimal price = ticketCalculator.Calculate(railwayConnection, parameters.NumberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, parameters.NumberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;
        }
    }
}
