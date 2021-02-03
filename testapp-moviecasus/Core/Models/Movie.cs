using System.Collections.Generic;

namespace Core.Models
{
    public class Movie
    {
        private string _title;
        private ICollection<MovieScreening> _screenings;

        public Movie(string title)
        {
            _title = title;

            _screenings = new List<MovieScreening>();
        }

        public string GetTitle()
        {
            return _title;
        }

        public void AddScreening(MovieScreening screening)
        {
            _screenings.Add(screening);
        }
    }
}
