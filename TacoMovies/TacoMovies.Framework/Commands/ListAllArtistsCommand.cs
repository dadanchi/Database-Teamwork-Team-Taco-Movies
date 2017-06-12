using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class ListAllArtists : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;

        public ListAllArtists(IMovieDbContext dbContext, IAuthProvider authProvider)
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
            var actors = this.dbContext.Artists
                .Join(this.dbContext.Countries, a => a.Id, c => c.Id,
                (a, c) => new { Artist = a.FirstName + " " + a.LastName,
                    a.DateOfBirth,
                    a.Profession,
                    Country = c.Name });

            var result = string.Join("\r\n", actors.ToList());
            return $"List of all artists : \r\n {result}";
        }
    }
}
