using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Range(4, 20)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(0, 1)]
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
