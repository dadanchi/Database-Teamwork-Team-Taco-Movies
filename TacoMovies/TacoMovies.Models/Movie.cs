using System;
using System.Collections.Generic;

namespace TacoMovies.Models
{
    public class Movie
    {
        private ICollection<Artist> actors;
        private ICollection<Genre> genres;

        public Movie()
        {
            this.actors = new HashSet<Artist>();
            this.genres = new HashSet<Genre>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public float Rating { get; set; }

        public DateTime PublishDate { get; set; }

        public int Length { get; set; }

        public virtual Artist Director { get; set; }

        public virtual int Coutry { get; set; }

        public virtual ICollection<Artist> Actors
        {
            get
            {
                return this.actors;
            }

            set
            {
                this.actors = value;
            }
        }

        public virtual ICollection<Genre> Genres
        {
            get
            {
                return this.genres;
            }

            set
            {
                this.genres = value;
            }
        }
    }
}
