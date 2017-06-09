using JSONParser;
using TacoMovies.Data;
using TacoMovies.JSONParser;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();

            //CountriesParser.Parse();
            //var artistParser = new ArtistsParser(dbContext);
            //artistParser.Parse();
            //var movieParser = new MovieParser(dbContext);
            //movieParser.Parse();

           
            
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
