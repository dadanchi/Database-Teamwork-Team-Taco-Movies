using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class SearchMovieByArtistCommand : ICommand
    {

        private readonly IMovieDbContext dbContext;

        public SearchMovieByArtistCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var firstName = parameters[0];
            var lastName = parameters[1];

            var moviesWithSelectedActor = dbContext.Artists
                             .Where(m => m.FirstName == firstName && m.LastName == lastName)
                             .SelectMany(m => m.Movies)
                             .ToList();

            foreach (var movie in moviesWithSelectedActor)
            {
                builder.AppendLine(movie.Name);
            }

            return $"The movie(s) with {firstName} {lastName} are :\n {builder.ToString()}";
            
        }
    }
}
