using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Data;
using TacoMovies.Models;

namespace JSONParser
{
    public class MovieParser
    {
        private readonly MoviesDbContext dbContext;

        public MovieParser(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Parse()
        {
            var json = File.ReadAllText("../../../ExternalData/movies.json");

            var jArray = JArray.Parse(json);

            foreach (var jObj in jArray)
            {
                var currentCountryName = jObj["Country"].ToString();

                var currentCountry = FindCurrentCountryId(currentCountryName);


                var movie = new Movie

                {
                    Name = (string)jObj["Name"],
                    Rating = (float)jObj["Rating"],
                    PublishDate = (DateTime.Parse((string)jObj["PublishDate"], new CultureInfo("en-CA"))),
                    Length = (int)jObj["Length"],
                    Coutry = currentCountry
                };
                Console.WriteLine(movie);
                this.dbContext.Movies.Add(movie);

            }

            this.dbContext.SaveChanges();

        }

        private Country FindCurrentCountryId(string currentCountryName)
        {

            var currentCountry = this.dbContext.Countries
                     .Where(c => c.Name == currentCountryName)
                     .FirstOrDefault();
        
            return currentCountry;
        }
    }
}
