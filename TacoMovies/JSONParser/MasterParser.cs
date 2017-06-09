using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.JSONParser;

namespace JSONParser
{
    public class MasterParser
    {
        private readonly MoviesDbContext dbContext;
        private readonly Utils utils;
        public MasterParser(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.utils = new Utils(this.dbContext);
        }

        public void Parse(string countryPath, string artistsPath, string moviesPath)
        {
            var countryPasrser = new CountriesParser(dbContext);
            countryPasrser.Parse(countryPath);

            var artistParser = new ArtistsParser(dbContext, utils);
            artistParser.Parse(artistsPath);

            var movieParser = new MovieParser(dbContext, utils);
            movieParser.Parse(moviesPath);
        }
    }
}