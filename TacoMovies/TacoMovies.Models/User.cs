using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [MaxLength(20), MinLength(4)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        [MaxLength(20), MinLength(4)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Authorization Authorization { get; set; }


        public virtual Account Account { get; set; }

        public virtual ICollection<Movie> Movies
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
