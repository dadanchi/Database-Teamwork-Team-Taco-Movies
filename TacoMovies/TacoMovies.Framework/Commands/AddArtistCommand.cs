using JSONParser;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public AddArtistCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.utils = new Utils(dbContext);
        }
        public string Execute(IList<string> parameters)
        {
            var artistFirstName = parameters[0];
            var artistLastName = parameters[1];
            var dateOfBirth = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            var profession = (Profession)Enum.Parse(typeof(Profession), parameters[3]);
            var countryToAdd = utils.FindCurrentCountry(parameters[4]);
            var awardName = parameters[5];

            var artist = new Artist
            {
                FirstName = artistFirstName,
                LastName = artistLastName,
                DateOfBirth = dateOfBirth,
                Profession = profession,
                Country = countryToAdd,
            };

            var awardToAdd = this.utils.FindCurrentAward(awardName);
            artist.Awards.Add(awardToAdd);

            dbContext.Artists.AddOrUpdate(n => new { n.FirstName, n.LastName}, artist);
            dbContext.SaveChanges();

            return $"{artist.FirstName} {artist.LastName} has been successfully added!";
        }
    }
}

