using System;
using TacoMovies.Contracts;
using TacoMovies.Data;
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
                case "add artist": return new AddArtistCommand(dbContext, authProvider, utils);
                case "add movie": return new AddUserMoviesCommand(dbContext, authProvider);
                case "logout": return new LogOutCommand(dbContext, authProvider);
                case "help": return new HelpCommand(authProvider);
                case "add award": return new AddAwardsCommand(dbContext, authProvider, utils);
                case "update artist info": return new UpdateArtistInfoCommand(dbContext, authProvider, utils);
                case "search movie by artist": return new SearchMovieByArtistCommand(dbContext);
                case "search actors by movie": return new SearchActorsByMovieCommand(dbContext);
                case "list my movies": return new ListMyMoviesCommand(dbContext, authProvider);
                case "list all artists": return new ListAllArtists(dbContext, authProvider);
                case "recharge account": return new RechargeAccountAmount(dbContext, authProvider);
                default: throw new Exception("There is no such command, enter Help to see all available commands");
            }
        }
    }
}