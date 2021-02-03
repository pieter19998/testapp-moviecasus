using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class F1Tests
    {
        [TestMethod]
        public void SecondTicketFreeIfStudent()
        {
            Order order = new Order(1, true);

            //MovieTicket ticket1 = new MovieTicket();

            double price = order.CalculatePrice();
        }

/*        public ICollection<MovieScreening> getMovies()
        {
            ICollection<MovieScreening> collection = new List<MovieScreening>();


            return new ICollection<>()
        }*/
    }
}
