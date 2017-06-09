using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using TacoMovies.Data;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace JSONParser
{
    public class ArtistsParser
    {
        private readonly MoviesDbContext dbContext;

        public ArtistsParser(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Parse()
        {
            var json = File.ReadAllText("../../../ExternalData/artist.json");

            var jArray = JArray.Parse(json);

            foreach (var jObj in jArray)
            {
                var currentCountryName = jObj["Country"].ToString();
                var currentCountry = FindCurrentCountry(currentCountryName);
                var professionToString = jObj["Profession"].ToString();

                var artist = new Artist
                {
                    FirstName = (string)jObj["FirstName"],
                    LastName = (string)jObj["LastName"],
                    DateOfBirth = (DateTime.Parse((string)jObj["DateOfBirth"], new CultureInfo("en-CA"))),
                    Profession = (Profession)Enum.Parse(typeof(Profession), professionToString),
                    Country = currentCountry,
                };

                this.dbContext.Artists.AddOrUpdate(c => new { c.FirstName, c.LastName }, artist);
            }

            this.dbContext.SaveChanges();

        }

        private Country FindCurrentCountry(string currentCountryName)
        {
            var currentCountry = this.dbContext.Countries
                     .Where(c => c.Name == currentCountryName)
                     .FirstOrDefault();

            return currentCountry;
        }
    }
}
