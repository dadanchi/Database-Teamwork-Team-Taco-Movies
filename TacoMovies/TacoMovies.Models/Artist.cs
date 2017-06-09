using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual Country Country { get; set; }

        [Required]
        [Range(0, 1)]
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

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
