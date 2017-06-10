using System;
using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    public class RegisterUserCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;

        public RegisterUserCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var password = parameters[1];
            var firstName = parameters[2];
            var lastName = parameters[3];

            var newUser = new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Authorization = Authorization.NormalUser
            };

            this.dbContext.Users.Add(newUser);

            dbContext.SaveChanges();

            return $"{newUser.Username} has successfully registered!";
        }
    }
}
