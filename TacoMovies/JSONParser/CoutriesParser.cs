using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Data;
using TacoMovies.Models;

namespace TacoMovies.JSONParser
{
    public static class CountriesParser
    {

        public static void Parse()
        {
            var json = File.ReadAllText("../../../ExternalData/Countries.json");

            var jArray = JArray.Parse(json);

            var dbContext = new MoviesDbContext();



            foreach (var jObj in jArray)
            {
                var movie = new Movie
                {
                    Name = (string)jObj["name"]["common"]
                    
                };
                dbContext.Movies.Add(movie);
            }

            dbContext.SaveChanges();


        }
    }

}
