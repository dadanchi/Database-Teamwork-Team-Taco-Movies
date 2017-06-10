using JSONParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Commands;
using TacoMovies.Models;

namespace TacoMovies.Framework.Factories
{
    public class CommandFactory : ICommandFactory
    {
        //public CommandFactory(IKernel kernel)
        //{

        //}

        public ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider, User user)
        {
            switch (commandAsString.ToLower())
            {
                case "register": return new RegisterUserCommand(dbContext);
                case "login": return new LoginCommand(dbContext, authProvider, user);
                case "create movie": return new CreateMovieCommand(dbContext);
                case "add artist": return new AddArtistCommand(dbContext);
                case "add award": return new AddAwardsCommand(dbContext);
                case "update director info": return new UpdateDirectorInfoCommand(dbContext);
                default: throw new Exception("There is no such command, enter Help to see all available commands");
            }
        }
    }
}
