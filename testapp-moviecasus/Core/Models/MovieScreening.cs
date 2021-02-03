using System;

namespace Core.Models
{
    public class MovieScreening
    {
        private Movie _movie;

        // LocalDate date = LocalDate.of(2000, Month.NOVEMBER, 20);
        private DateTime _dateAndTime;
        private double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _movie = movie;
            movie.AddScreening(this);

            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return _pricePerSeat;
        }

        public override string ToString()
        {
            return _movie.GetTitle() + " - " + _dateAndTime;
        }
    }
}
