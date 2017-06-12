using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Helpers;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    /// <summary>
    /// not working - need to fix it
    /// </summary>
    public class RegisterUserCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;

        public RegisterUserCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];
            var firstName = parameters[2];
            var lastName = parameters[3];

            var account = AccountCreator.CreateAccount();

            var newUser = new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Authorization = Authorization.NormalUser,
                Account = account
            };

            this.dbContext.Users.Add(newUser);

            dbContext.SaveChanges();

            this.authProvider.CurrentUsername = newUser.Username;

            return $"{newUser.Username} has successfully registered! You are now logged in.\n Type a command or 'help logged user' for help to see your options.";
        }
    }
}