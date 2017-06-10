using System;
using System.Collections.Generic;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    class AddUserMoviesCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;

        public AddUserMoviesCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;

            if (this.authProvider.CurrentUsername == string.Empty)
            {
                throw new Exception("You are currently not logged in.");
            }
        }

        public string Execute(IList<string> parameters)
        {
            var title = parameters[0].ToLower();
            var currentUsername = this.authProvider.CurrentUsername;

            var movie = this.dbContext.Movies
                .Where(x => x.Name.ToLower() == title)
                .FirstOrDefault();

            this.dbContext.Users
                .Where(x => x.Username == currentUsername)
                .FirstOrDefault()
                .Movies.Add(movie);

            dbContext.SaveChanges();

            return $"{currentUsername} has successfully added the movie {movie.Name} to their list!";
        }
    }
}