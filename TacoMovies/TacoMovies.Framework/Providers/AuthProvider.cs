using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Framework.Providers
{
    public class AuthProvider : IAuthProvider
    {
        public User LogInUser(string username, string password, IMovieDbContext dbContext)
        {
            var user = dbContext.Users
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefault();

            // validate somewhere here
            if (user == null)
            {
                throw new ArgumentException("Username/password not found");
            }

            return user;
        }
    }
}
