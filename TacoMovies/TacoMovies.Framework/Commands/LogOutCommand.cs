using System;
using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    class LogOutCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;

        public LogOutCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;

            if (this.authProvider.CurrentUsername == string.Empty)
            {
                throw new Exception("You are not logged in to log out");
            }
        }

        public string Execute(IList<string> parameters)
        {
            var username = this.authProvider.CurrentUsername;

            this.authProvider.LogOut();

            return $"{username} has successfully logged out!";
        }
    }
}