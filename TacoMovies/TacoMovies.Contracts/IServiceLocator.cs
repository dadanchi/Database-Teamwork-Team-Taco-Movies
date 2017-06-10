using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Contracts
{
    public interface IServiceLocator
    {
        ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider, User user);
    }
}
