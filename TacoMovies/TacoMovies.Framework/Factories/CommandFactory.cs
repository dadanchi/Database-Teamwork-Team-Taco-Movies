using System;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Commands;

namespace TacoMovies.Framework.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider,
             IReader reader, IWriter writer, IUtils utils)
        {
            switch (commandAsString.ToLower())
            {
                case "register": return new RegisterUserCommand(dbContext, authProvider);
                case "login": return new LoginCommand(dbContext, authProvider);
                case "create movie": return new CreateMovieCommand(dbContext, authProvider, reader, writer, utils);
                case "add artist": return new AddArtistCommand(dbContext, authProvider);
                case "add movie": return new AddUserMoviesCommand(dbContext, authProvider);
                case "logout": return new LogOutCommand(dbContext, authProvider);
                case "help": return new HelpCommand();
                case "add award": return new AddAwardsCommand(dbContext); // add authprovider and check authorizatoin
                case "update director info": return new UpdateDirectorInfoCommand(dbContext); // same
                default: throw new Exception("There is no such command, enter Help to see all available commands");
            }
        }
    }
}