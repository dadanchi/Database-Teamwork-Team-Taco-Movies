using TacoMovies.Data;

namespace TacoMovies.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandAsString, MoviesDbContext dbContext);
    }
}
