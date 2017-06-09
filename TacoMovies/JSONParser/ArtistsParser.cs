using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace JSONParser
{
    public class ArtistsParser 
    {
        private readonly MoviesDbContext dbContext;
        private readonly Utils utils;

        public ArtistsParser(MoviesDbContext dbContext, Utils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils;
        }
        public void Parse(string path)
        {
            var json = File.ReadAllText(path);

            var jArray = JArray.Parse(json);

            foreach (var jObj in jArray)
            {
                var currentCountryName = jObj["Country"].ToString();
                var currentCountry = this.utils.FindCurrentCountry(currentCountryName);
                var professionToString = jObj["Profession"].ToString();

                var artist = new Artist
                {
                    FirstName = (string)jObj["FirstName"],
                    LastName = (string)jObj["LastName"],
                    DateOfBirth = (DateTime.Parse((string)jObj["DateOfBirth"], new CultureInfo("en-CA"))),
                    Profession = (Profession)Enum.Parse(typeof(Profession), professionToString),
                    Country = currentCountry,
                };

                var awards = jObj["Awards"];
                foreach (var award in awards)
                {
                    if (!string.IsNullOrEmpty(award.ToString()))
                    {
                        var newAward = this.utils.FindCurrentAward(award.ToString());
                        artist.Awards.Add(newAward);
                    }
                }

                this.dbContext.Artists.AddOrUpdate(c => new { c.FirstName, c.LastName }, artist);
            }

            this.dbContext.SaveChanges();
        }
    }
}
