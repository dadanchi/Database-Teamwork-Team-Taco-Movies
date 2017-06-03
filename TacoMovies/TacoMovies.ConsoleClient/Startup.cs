using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.JSONParser;
using TacoMovies.Models;

namespace TacoMovies.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            CountriesParser.Parse();
        }
    }
}
