using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        [ForeignKey("DirectorId")]
        [Required]
        public virtual Artist Director { get; set; }
        public int? DirectorId { get; set; }

        [Required]
        public virtual Country Coutry { get; set; }

        [Required]
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

        [Required]
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

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.Name);
            builder.AppendLine(this.Rating.ToString());
            builder.AppendLine(this.PublishDate.ToString());
            builder.AppendLine(this.Length.ToString());

            return builder.ToString();

        }
    }
}
