using System;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Framework.Providers
{
    public static class Validator
    {
        private const string MovieDoesNotExistMessage = "This movie does not exist!";
        private const string IncorectUsernameOrPassword = "The username / password must be between 4 and 20 symbols inclusive!";
        private const string TakenUsernameMessage = "This username is already taken!";
        static Validator()
        {
        }

        public static bool ValidateUsernameOrPassword(string input, IWriter writer)
        {
            if (input.Length < 4 || input.Length > 20)
            {
                writer.WriteLine(IncorectUsernameOrPassword);
                return false;
            }

            return true;
        }

        public static bool IsUsernameTaken(string username, IMovieDbContext dbContext, IWriter writer)
        {
            var user = dbContext.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user != null)
            {
                writer.WriteLine(TakenUsernameMessage);
                return true;
            }

            return false;
        }

        public static bool DoesMovieExist(string movieName, IMovieDbContext dbContext, IWriter writer)
        {
            var movie = dbContext.Movies.Where(x => x.Name == movieName).FirstOrDefault();

            if (movie != null)
            {
                //writer.WriteLine(MovieDoesNotExistMessage);
                return true;
            }

            return false;
        }

        public static void IsUserAuhtorised(IAuthProvider authProvider)
        {
            if (authProvider.CurrentUsername == string.Empty)
            {
                throw new Exception("You must be logged in for this command");
            }

            if (!authProvider.IsAuthorized())
            {
                throw new Exception("You don't have authority for this command");
            }
        }

        public static void IsUserAmoutEnough(User user, int priceOfOneMovie)
        {
            if(user.Account.Ammount < priceOfOneMovie)
            {
                throw new Exception("You do not have enough money!");
            }
        }
    }
}