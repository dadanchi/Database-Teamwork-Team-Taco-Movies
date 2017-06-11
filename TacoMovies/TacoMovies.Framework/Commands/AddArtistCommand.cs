using JSONParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    public class AddArtistCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IUtils utils;
        private readonly IAuthProvider authProvider;

        public AddArtistCommand(IMovieDbContext dbContext, IAuthProvider authProvider, IUtils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils;
            this.authProvider = authProvider;

            Validator.IsUserAuhtorised(authProvider);
        }

        public string Execute(IList<string> parameters)
        {
            var artistFirstName = parameters[0];
            var artistLastName = parameters[1];
            var dateOfBirth = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            var profession = (Profession)Enum.Parse(typeof(Profession), parameters[3]);
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