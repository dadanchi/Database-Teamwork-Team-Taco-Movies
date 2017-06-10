using System;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Providers
{
    public class Validator
    {
        private const string IncorectUsernameOrPassword = "Input should be between 4 and 20 character inclusive.\n Enter again : ";
        private const string TakenUsernameMessage = "Username is taken.\n Enter again : ";

        private readonly IWriter writer;
        private readonly IReader reader; 
        public Validator(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
        }

        public bool ValidateUsernameOrPassword(string input)
        {
            if(input.Length < 4 || input.Length > 20)
            {
                this.writer.WriteLine(IncorectUsernameOrPassword);
                return false;
            }

            return true;
        }

        public bool IsUsernameTaken(string username, IMovieDbContext dbContext)
        {
            var user = dbContext.Users.Where(x => x.Username == username).FirstOrDefault();

            if(user != null)
            {
                this.writer.WriteLine(TakenUsernameMessage);
                return true;
            }

            return false;
        }
    }
}
