﻿using JSONParser;
using System;
using System.Linq;
using TacoMovies.Data;
using TacoMovies.JSONParser;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();
            var utils = new Utils(dbContext);

            var countryPasrser = new CountriesParser(dbContext);
            countryPasrser.Parse();

            var artistParser = new ArtistsParser(dbContext, utils);
            artistParser.Parse();

            var movieParser = new MovieParser(dbContext, utils);
            movieParser.Parse();

        }
    }
}
