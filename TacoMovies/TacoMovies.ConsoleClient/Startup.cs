using JSONParser;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Data;
using TacoMovies.JSONParser;
using TacoMovies.Models;
using System.Data.Entity.Migrations;
using TacoMovies.Data.Migrations;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();

            //CountriesParser.Parse();

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesDbContext, Configuration>());

            //var movieParser = new MovieParser(dbContext);
            //movieParser.Parse();

            var artistParser = new ArtistsParser(dbContext);
            artistParser.Parse();

            //var ee1 = dbContext.Artists
            //                  .Where(j => j.FirstName == "Leonardo")
            //                  .FirstOrDefault();
            //Console.WriteLine(ee1.Movies.Count);

            //foreach (var item in ee1.Movies)
            //{
            //    Console.WriteLine(item.Name);
            //}


        }
    }
}
