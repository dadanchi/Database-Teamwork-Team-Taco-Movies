using Newtonsoft.Json.Linq;
using System.Data.Entity.Migrations;
using System.IO;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Models;

namespace TacoMovies.JSONParser
{
    public class CountriesParser 
    {
        private readonly MoviesDbContext dbContext;

        public CountriesParser(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Parse(string path)
        {
            var json = File.ReadAllText(path);

            var jArray = JArray.Parse(json);

            var dbContext = new MoviesDbContext();
            
            foreach (var jObj in jArray)
            {
                var country = new Country
                {
                    Name = (string)jObj["name"]["common"]
                };

                dbContext.Countries.AddOrUpdate(c => c.Name, country);
                
            }

            dbContext.SaveChanges();
        }
    }
}