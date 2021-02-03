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
            double sum = 0.0;
            uint count = 0;
            foreach (MovieTicket ticket in _tickets)
            {
                ++count;
                double ticketPrice = ticket.GetPrice();
                
                if (ticket.IsPremiumTicket())
                {
                    if (_isStudentOrder)
                    {
                        ticketPrice += 2;
                    }
                    else
                    {
                        ticketPrice += 3;
                    }
                }

                if (ticket.Screening.DateAndTime.IsWeekDay())
                {
                    if (count % 2 == 0)
                    {
                        ticketPrice = 0;
                    }
                }
                else
                {
                    if (_isStudentOrder)
                    {
                        if (count % 2 == 0)
                        {
                            ticketPrice = 0;
                        }
                    }
                    else
                    {
                        if (_tickets.Count >= 6)
                            ticketPrice *= 0.9;
                    }
                }

                sum += ticketPrice;
            }
            return sum;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            // Bases on the string respresentations of the tickets (toString), write
            // the ticket to a file with naming convention Order_<orderNr>.txt of
            // Order_<orderNr>.json
        }
    }
}
