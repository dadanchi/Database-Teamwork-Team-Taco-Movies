using System;
using System.Collections.Generic;
using TacoMovies.Models.Enums;

namespace TacoMovies.Models
{
    public class Artist
    {
        private ICollection<Award> awards;
        private ICollection<Movie> movies;

        public Artist()
        {
            this.awards = new HashSet<Award>();
            this.movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual Country Country { get; set; }

        public virtual Profession Profession { get; set; }

        public virtual ICollection<Award> Awards
        {
            get
            {
                return this.awards;
            }

            set
            {
                this.awards = value;
            }
        }

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
