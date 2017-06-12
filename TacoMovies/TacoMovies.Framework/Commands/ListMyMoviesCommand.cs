using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;

namespace TacoMovies.Framework.Commands
{
    public class ListMyMoviesCommand : ICommand
    {
        private IMovieDbContext dbContext;
        private IAuthProvider authProvider;

        public ListMyMoviesCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;
        }


        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();

            var currentUser = this.authProvider.CurrentUsername;

            var moviesOfUser = this.dbContext.Users
                                     .Where(x => x.Username == currentUser)
                                     .First();

            foreach (var movie in moviesOfUser.Movies)
            {
                builder.AppendLine(movie.Name);
            }

            return $"The movies in the list of {currentUser} are : \n {builder.ToString()}";

        }
    }
}
