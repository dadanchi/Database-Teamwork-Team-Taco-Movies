using JSONParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    public class AddArtistCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly Utils utils;
        private readonly IAuthProvider authProvider;

        public AddArtistCommand(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.utils = new Utils(dbContext);
            this.authProvider = authProvider;

            if (this.authProvider.CurrentUsername == string.Empty)
            {
                throw new Exception("You must be logged in for this command");
            }

            if (!this.authProvider.IsAuthorized())
            {
                throw new Exception("You don't have authority for this command");
            }
        }

        public string Execute(IList<string> parameters)
        {
            var artistFirstName = parameters[0];
            var artistLastName = parameters[1];
            var dateOfBirth = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            var profession = (Profession)Enum.Parse(typeof(Profession), parameters[3].ToLower());
            var countryToAdd = utils.FindCurrentCountry(parameters[4]);

            var artist = new Artist
            {
                FirstName = artistFirstName,
                LastName = artistLastName,
                DateOfBirth = dateOfBirth,
                Profession = profession,
                Country = countryToAdd,
            };

            dbContext.Artists.Add(artist);
            dbContext.SaveChanges();

            return $"{artist.FirstName} {artist.LastName} has been successfully added!";
        }
    }
}