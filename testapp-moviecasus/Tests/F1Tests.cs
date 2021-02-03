using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestClass]
    public class F1Tests
    {
        [TestMethod]
        public void SecondTicketFreeIfStudent()
        {
            //arrange
            Order order = new Order(1, true);

            MovieTicket ticket1 = new MovieTicket(getMovies()[0], false, 5, 28);
            MovieTicket ticket2 = new MovieTicket(getMovies()[0], false, 5, 28);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            //act
            double singleTicketPrice = ticket1.GetPrice();
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(singleTicketPrice, orderPrice);
        }
        [TestMethod]
        public void SecondsTicketFreeIfMidWeekIfNotStudent()
        {
            //arrange
            Order order = new Order(1, false);

            MovieTicket ticket1 = new MovieTicket(getMovies()[0], false, 5, 28);
            MovieTicket ticket2 = new MovieTicket(getMovies()[0], false, 5, 28);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            //act
            double singleTicketPrice = ticket1.GetPrice();
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(singleTicketPrice, orderPrice);
        }

        [TestMethod]
        public void SecondsTicketNotFreeIfWeekendIfNotStudent()
        {
            //arrange
            Order order = new Order(1, false);

            MovieTicket ticket1 = new MovieTicket(getMovies()[1], false, 5, 28);
            MovieTicket ticket2 = new MovieTicket(getMovies()[1], false, 5, 28);

            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);

            //act
            double targetPrice = ticket1.GetPrice() + ticket2.GetPrice();
            double orderPrice = order.CalculatePrice();

            //assert
            Assert.AreEqual(targetPrice, orderPrice);
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
