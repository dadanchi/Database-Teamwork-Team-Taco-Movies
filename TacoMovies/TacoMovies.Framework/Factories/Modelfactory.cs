using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Models;

namespace TacoMovies.Framework.Factories
{
    public class Modelfactory
    {
        public User CreateUser(string username, string password, string firstName, string lastName)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            return user;
        }
    }
}
