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
        public ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider, User user)
        {
            switch (commandAsString.ToLower())
            {
                case "register": return new RegisterUserCommand(dbContext);
                case "login": return new LoginCommand(dbContext, authProvider, user);
                default: return null;

            }
        }
    }
}
