using TacoMovies.Data.Contracts;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.Contracts
{
    public interface IUtils
    {
        Country FindCurrentCountry(string currentCountryName);

        Genre FindCurrentGenre(string genreName);

        Artist FindCurrentArtist(string actorName, Profession profession);

        Award FindCurrentAward(string currentAwardName);
    }
}
