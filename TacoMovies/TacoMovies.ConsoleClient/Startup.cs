using JSONParser;
using Ninject;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using TacoMovies.ConsoleClient.Container;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Framework.Core;
using TacoMovies.Framework.Factories;
using TacoMovies.Framework.Providers;
using TacoMovies.JSONParser;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();

            //var parser = new MasterParser(dbContext);
            //parser.Parse("../../../ExternalData/Countries.json", "../../../ExternalData/artist.json",
            //"../../../ExternalData/movies.json");
            var kernel = new StandardKernel(new MoviesNinjectModule());

            var engine = kernel.Get<IEngine>();
            engine.Start();

        }
    }
}
