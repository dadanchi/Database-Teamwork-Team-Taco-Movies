using System.Collections.Generic;
using TacoMovies.Models.Enums;

namespace TacoMovies.Models
{
    public class User
    {
        private ICollection<Movie> movies;

        public User()
        {
            this.movies = new HashSet<Movie>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Authorization Authorization { get; set; }

        public ICollection<Movie> Movies
        {
            get
            {
                return this.movies;
            }

            set
            {
                this.movies = value;
            }
        }
    }
}
