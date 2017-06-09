using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TacoMovies.Models
{
    public class Award
    {
        private ICollection<Artist> artists;
        public Award()
        {
            this.artists = new HashSet<Artist>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public virtual ICollection<Artist> Artists
        {
            get
            {
                return this.artists;
            }

            set
            {
                this.artists = value;
            }
        }
    }
}
