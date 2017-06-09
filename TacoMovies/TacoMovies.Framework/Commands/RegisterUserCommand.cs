using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    public class RegisterUserCommand : ICommand
    {
        private readonly MoviesDbContext dbContext;

        public RegisterUserCommand(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Execute(IList<string> parameters)
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
        }
    }
}
