using System;
using System.Collections.Generic;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Framework.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;
        private User user;

        public LoginCommand(IMovieDbContext dbContext, IAuthProvider authProvider, User user)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;
            this.user = user;

        }

        public void Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];

            this.user = this.authProvider.LogInUser(username, password, dbContext);
            
        }
    }
}
