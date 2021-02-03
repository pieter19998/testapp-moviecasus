using System.Collections.Generic;

namespace Core.Models
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;

        private ICollection<MovieTicket> _tickets;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;

            _tickets = new List<MovieTicket>();
        }

        public int GetOrderNr()
        {
            return _orderNr;
        }

        public void AddSeatReservation(MovieTicket ticket)
        {
            _tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            return 0;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            // Bases on the string respresentations of the tickets (toString), write
            // the ticket to a file with naming convention Order_<orderNr>.txt of
            // Order_<orderNr>.json
        }
    }
}
