using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Contracts
{
    public interface IAuthProvider
    {
        User LogInUser(string username, string password, IMovieDbContext dbContext);
    }
}
