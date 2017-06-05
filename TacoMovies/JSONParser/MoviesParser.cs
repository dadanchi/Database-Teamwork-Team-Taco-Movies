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
       public static void Parse()
        {
            var json = File.ReadAllText("../../../ExternalData/movies.json");

            var jArray = JArray.Parse(json);

            var dbContext = new MoviesDbContext();

            foreach (var jObj in jArray)
            {
                
                var movie = new Movie

                {
                    Name = (string)jObj["Name"],
                    Rating = (float)jObj["Rating"],
                    PublishDate = (DateTime.Parse((string)jObj["PublishDate"], new CultureInfo("en-CA"))),
                    Length = (int)jObj["Length"],
                };

                dbContext.Movies.Add(movie);
            }

            dbContext.SaveChanges();

        }

        // Potencial logic for retrievin country id (not working because of incompatibility between newtonsof en LINQ)

        //private int FindCurrentCountryId()
        //{
        //    var cueerntCountry = dbContext.Countries
        //                .FirstOrDefault(c => c.Name == jObj["name"]["common"].ToString());
        //    var currentCountryId = cueerntCountry.Id;
        //}
    }
}
