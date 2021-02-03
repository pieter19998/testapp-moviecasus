namespace Core.Models
{
    public class MovieTicket
    {
        private MovieScreening _movieScreening;
        private bool _isPremiumTicket;

        private int _seatRow;
        private int _seatNr;

        public MovieTicket(
            MovieScreening movieScreening,
            bool isPremiumTicket,
            int seatRow,
            int seatNr)
        {
            _movieScreening = movieScreening;
            _isPremiumTicket = isPremiumTicket;
            _seatRow = seatRow;
            _seatNr = seatNr;
        }

        public MovieScreening Screening => _movieScreening;

        public bool IsPremiumTicket()
        {
            return _isPremiumTicket;
        }

        public double GetPrice()
        {
            return _movieScreening.GetPricePerSeat();
        }

        public override string ToString()
        {
            return _movieScreening.ToString() + " - row " + _seatRow + ", seat " + _seatNr +
                   (_isPremiumTicket ? " (Premium)" : "");
        }
    }
}
