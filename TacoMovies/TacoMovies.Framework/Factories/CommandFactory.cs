using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Framework.Commands;

namespace TacoMovies.Framework.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string commandAsString, MoviesDbContext dbContext)
        {
            switch (commandAsString.ToLower())
            {
                case "register": return new RegisterUserCommand(dbContext);
                default: return null;

            }
        }
    }
}
