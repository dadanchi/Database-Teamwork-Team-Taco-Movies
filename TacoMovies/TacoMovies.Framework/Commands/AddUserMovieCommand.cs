using System;
using System.Collections.Generic;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;

namespace TacoMovies.Framework.Commands
{
    class AddUserMoviesCommand : ICommand
    {
        private const int PriceOfOneMovie = 10;

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

            var user = this.dbContext.Users
                       .Where(x => x.Username == currentUsername)
                       .FirstOrDefault();

            Validator.IsUserAmoutEnough(user, PriceOfOneMovie);
            user.Movies.Add(movie);
            user.Account.Ammount -= user.Account.Ammount - PriceOfOneMovie;



            dbContext.SaveChanges();

            return $"{currentUsername} has successfully added the movie {movie.Name} to their list!";
        }
    }
}