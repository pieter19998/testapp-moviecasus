using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class F3Tests
    {
        [TestMethod]
        public void PremiumTicketAdded2EuroIfStudent()
        {
            //arrange
            Order order = new Order(1, true);
            MovieTicket ticket1 = new MovieTicket(getMovies()[0], true, 5, 28);
            order.AddSeatReservation(ticket1);

            //act
            double targetTicketPrice = ticket1.GetPrice() + 2.0;
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(targetTicketPrice, orderPrice);
        }

        [TestMethod]
        public void PremiumTicketAdded3EuroIfNotStudent()
        {
            //arrange
            Order order = new Order(1, false);
            MovieTicket ticket1 = new MovieTicket(getMovies()[0], true, 5, 28);
            order.AddSeatReservation(ticket1);

            //act
            double targetTicketPrice = ticket1.GetPrice() + 3.0;
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(targetTicketPrice, orderPrice);
        }

        [TestMethod]
        public void PremiumTicketAdded3EuroSecondTicketNoExtraCosts()
        {
            //arrange
            Order order = new Order(1, false);
            MovieTicket ticket1 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket2 = new MovieTicket(getMovies()[0], true, 5, 28);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            //act
            double targetTicketPrice = ticket1.GetPrice() + 3.0;
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(targetTicketPrice, orderPrice);
        }

        [TestMethod]
        public void PremiumTicketAdded3EuroAlsoOnSales()
        {
            //arrange
            Order order = new Order(1, false);
            MovieTicket ticket1 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket2 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket3 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket4 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket5 = new MovieTicket(getMovies()[0], true, 5, 28);
            MovieTicket ticket6 = new MovieTicket(getMovies()[0], true, 5, 28);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);

            //act
            double targetTicketPrice = ((ticket1.GetPrice() + 3) * 3) * 0.9;
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(targetTicketPrice, orderPrice);
        }


        public List<MovieScreening> getMovies()
        {
            List<MovieScreening> collection = new List<MovieScreening>();

            //midweek
            collection.Add(new MovieScreening(
                new Movie("Henk en de UberCharge"),
                DateTime.Parse("Jan 1, 2009"),
                14.0
            ));

            //in weekend
            collection.Add(new MovieScreening(
                new Movie("Kaas is een Zoogdier"),
                DateTime.Parse("Feb 6, 2021"),
                14.0
            ));

            //midweek
            collection.Add(new MovieScreening(
                new Movie("Namaak kaas"),
                DateTime.Parse("Jan 1, 2009"),
                14.0
            ));


            return collection;
        }
    }
}
