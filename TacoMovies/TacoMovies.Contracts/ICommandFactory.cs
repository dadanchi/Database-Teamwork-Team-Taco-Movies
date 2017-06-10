using TacoMovies.Data;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider,
             IReader reader, IWriter writer, IUtils utils);
    }
}
