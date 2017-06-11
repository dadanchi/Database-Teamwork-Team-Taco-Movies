using System.Data.Entity;
using TacoMovies.Models;

namespace TacoMovies.Data.Contracts
{
    public interface IMovieDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Artist> Artists { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Genre> Genres { get; set; }

        IDbSet<Award> Awards { get; set; }

        IDbSet<Country> Countries { get; set; }

        int SaveChanges();

        void Dispose();
    }
}
