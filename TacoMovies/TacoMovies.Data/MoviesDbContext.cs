using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Models;

namespace TacoMovies.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("MoviesDB")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Genre> Genres { get; set; }

        public virtual IDbSet<Award> Awards { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

    }
}
