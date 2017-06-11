using System.Data.Entity.Migrations;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace JSONParser
{
    public class Utils : IUtils
    {
        private readonly IMovieDbContext dbContext;

        public Utils(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Country FindCurrentCountry(string currentCountryName)
        {
            var currentCountry = this.dbContext.Countries
                     .Where(c => c.Name == currentCountryName)
                     .FirstOrDefault();

            return currentCountry;
        }

        public Genre FindCurrentGenre(string genreName)
        {
            var genre = this.dbContext.Genres
                     .Where(c => c.Name == genreName)
                     .FirstOrDefault();

            if (genre == null)
            {
                genre = new Genre()
                {
                    Name = genreName
                };

                dbContext.Genres.AddOrUpdate(n => n.Name, genre);
            }

            return genre;
        }
        
        public Artist FindCurrentArtist(string actorName, Profession profession)
        {
            var artistAsString = actorName.ToString().Split(' ');
            var firstName = artistAsString[0];
            string lastName = "";

            if (!string.IsNullOrEmpty(artistAsString[1]))
            {
                lastName = artistAsString[1];
            }
            

            var artist = this.dbContext.Artists
                .Where(x => x.FirstName == firstName && x.LastName == lastName)
                .FirstOrDefault();

            if (artist == null)
            {
                var newArtist = new Artist()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Profession = profession,
                };

                dbContext.Artists.AddOrUpdate(n => new { n.FirstName, n.LastName }, newArtist);

                return newArtist;
                
            }

            return artist;
        }

        public Award FindCurrentAward(string currentAwardName)
        {
            var currentAward = this.dbContext.Awards
                     .Where(c => c.Name == currentAwardName)
                     .FirstOrDefault();

            if (currentAward == null)
            {
                return new Award()
                {
                    Name = currentAwardName
                };
            }

            return currentAward;
        }
    }
}
