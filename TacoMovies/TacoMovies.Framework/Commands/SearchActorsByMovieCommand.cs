using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class SearchActorsByMovieCommand : ICommand
    {
        private IMovieDbContext dbContext;

        public SearchActorsByMovieCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Execute(IList<string> parameters)
        {
            var builder = new StringBuilder();
            var movineName = parameters[0];

            var actorsInMovie = dbContext.Movies
                             .Where(m => m.Name == movineName)
                             .SelectMany(m => m.Actors)
                             .ToList();

            foreach (var actor in actorsInMovie)
            {
                builder.AppendLine(actor.FirstName + " " +  actor.LastName);
            }

            return $"The actors in {movineName} are :\n {builder.ToString()}";
        }
    }
}
