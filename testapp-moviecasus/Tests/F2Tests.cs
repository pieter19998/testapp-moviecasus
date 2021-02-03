using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class F2Tests {

        public IList<MovieScreening> getMovies() {
            List<MovieScreening> collection = new List<MovieScreening>();

            collection.Add(new MovieScreening(
                new Movie("Henk en de UberCharge"),
                DateTime.Parse("Jan 1, 2009"),
                14.0
            ));

            collection.Add(new MovieScreening(
                new Movie("Kaas is een Zoogdier"),
                DateTime.Parse("Jan 1, 2009"),
                14.0
            ));

            collection.Add(new MovieScreening(
                new Movie("Namaak kaas"),
                DateTime.Parse("Jan 1, 2009"),
                14.0
            ));


            return collection;
        }

        [TestMethod]
        public void FullPriceInWeekend()
        {
            //arrange
            //create a movie that is in the weekend
            var sample = new MovieScreening(new Movie("Sjaak wordt geslagen op zijn kaak"), DateTime.Parse("Jan 29, 2021"), 14.0);
            MovieTicket ticket = new MovieTicket(sample, false, 5, 28);
            Order order = new Order(1, false);
            //act
            order.AddSeatReservation(ticket);
            //assert
            Assert.AreEqual(order.CalculatePrice(), ticket.GetPrice()); //assume that the price is equal as it should be full price.
        }

        [TestMethod]
        public void TenPercentDiscountInWeekendWhenExceedingSixTickets()
        {
            //arrange
            var sample1 = new MovieScreening(new Movie("Sjaak wordt geslagen op zijn kaak"), DateTime.Parse("Jan 29, 2021"), 14.0);
            MovieTicket ticket1 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket2 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket3 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket4 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket5 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket6 = new MovieTicket(sample1, false, 5, 28);
            MovieTicket ticket7 = new MovieTicket(sample1, false, 5, 28);
            Order order = new Order(1, false);
            //act
            order.AddSeatReservation(ticket1);
            order.AddSeatReservation(ticket2);
            order.AddSeatReservation(ticket3);
            order.AddSeatReservation(ticket4);
            order.AddSeatReservation(ticket5);
            order.AddSeatReservation(ticket6);
            order.AddSeatReservation(ticket7);
            //assert
            Assert.AreEqual(Math.Round(order.CalculatePrice()), (Math.Round(ticket1.GetPrice()*7 * 0.9))); //10% discount assumed
        }
    }
}
