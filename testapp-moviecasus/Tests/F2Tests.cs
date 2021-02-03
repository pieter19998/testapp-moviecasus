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
            var _sample = new MovieScreening(new Movie("Sjaak wordt geslagen op zijn kaak"), DateTime.Parse("Jan 29, 2021"), 14.0);
            MovieTicket _ticket = new MovieTicket(_sample, false, 5, 28);
            Order _order = new Order(1, false);
            //act
            _order.AddSeatReservation(_ticket);
            //assert
            Assert.AreEqual(_order.CalculatePrice(), _ticket.GetPrice()); //assume that the price is equal as it should be full price.
        }

        [TestMethod]
        public void TenPercentDiscountInWeekendWhenExceedingSixTickets()
        {
            //arrange
            var _sample1 = new MovieScreening(new Movie("Sjaak wordt geslagen op zijn kaak"), DateTime.Parse("Jan 29, 2021"), 14.0);
            MovieTicket _ticket1 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket2 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket3 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket4 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket5 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket6 = new MovieTicket(_sample1, false, 5, 28);
            MovieTicket _ticket7 = new MovieTicket(_sample1, false, 5, 28);
            Order _order = new Order(1, false);
            //act
            _order.AddSeatReservation(_ticket1);
            _order.AddSeatReservation(_ticket2);
            _order.AddSeatReservation(_ticket3);
            _order.AddSeatReservation(_ticket4);
            _order.AddSeatReservation(_ticket5);
            _order.AddSeatReservation(_ticket6);
            _order.AddSeatReservation(_ticket7);
            //assert
            Assert.AreEqual(Math.Round(_order.CalculatePrice()), (Math.Round(_ticket1.GetPrice()*7 * 0.9))); //10% discount assumed
        }
    }
}
