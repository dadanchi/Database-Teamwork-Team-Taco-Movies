﻿using JSONParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Data;
using TacoMovies.JSONParser;
using TacoMovies.Models;

namespace TacoMovies.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();
            //CountriesParser.Parse();

            var movieParser = new MovieParser(dbContext);
            movieParser.Parse();
            
        }
    }
}
