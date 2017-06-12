using System;
using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;

        public LoginCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;

            if (this.authProvider.CurrentUsername != string.Empty)
            {
                throw new Exception($"User {authProvider.CurrentUsername} is already logged in.");
            }
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];

            this.authProvider.LogInUser(username, password);                                        

            return $"{username} has successfully logged in!\n Type a command or 'help logged user' for help to see your options.";
        }
    }
}