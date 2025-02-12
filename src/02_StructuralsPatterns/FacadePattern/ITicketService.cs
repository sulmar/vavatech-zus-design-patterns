using FacadePattern.Models;
using FacadePattern.Repositories;
using FacadePattern.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    // Abstract Facade
    public interface ITicketService
    {
        Ticket Buy(RailwayConnectionOptions options);
        void Cancel(Ticket ticket);
    }

    public class RailwayConnectionOptions
    {
        public string from { get; set; }
        public string to { get; set; }
        public DateTime when { get; set; }
        public byte numberOfPlaces { get; set; }
    }

    // Concrete Facade
    public class PkpTicketService : ITicketService
    {
        RailwayConnectionRepository railwayConnectionRepository;
        TicketCalculator ticketCalculator;
        ReservationService reservationService;
        PaymentService paymentService;
        EmailService emailService;

        public PkpTicketService(RailwayConnectionRepository railwayConnectionRepository, TicketCalculator ticketCalculator, ReservationService reservationService, PaymentService paymentService, EmailService emailService)
        {
            this.railwayConnectionRepository = railwayConnectionRepository;
            this.ticketCalculator = ticketCalculator;
            this.reservationService = reservationService;
            this.paymentService = paymentService;
            this.emailService = emailService;
        }

        public Ticket Buy(RailwayConnectionOptions options)
        {
            RailwayConnection railwayConnection = railwayConnectionRepository.Find(options.from, options.to, options.when);
            decimal price = ticketCalculator.Calculate(railwayConnection, options.numberOfPlaces);
            Reservation reservation = reservationService.MakeReservation(railwayConnection, options.numberOfPlaces);
            Ticket ticket = new Ticket { RailwayConnection = reservation.RailwayConnection, NumberOfPlaces = reservation.NumberOfPlaces, Price = price };
            Payment payment = paymentService.CreateActivePayment(ticket);
            ticket.Payment = payment;

            if (payment.IsPaid)
            {
                emailService.Send(ticket);
            }

            return ticket;

        }

        public class NextPkpTicketService : ITicketService
        {
            public Ticket Buy(RailwayConnectionOptions options)
            {
                throw new NotImplementedException();
            }

            public void Cancel(Ticket ticket)
            {
                throw new NotImplementedException();
            }
        }

        public void Cancel(Ticket ticket)
        {
            // Act
            reservationService.CancelReservation(ticket.RailwayConnection, ticket.NumberOfPlaces);
            paymentService.RefundPayment(ticket.Payment);
        }
    }
}
