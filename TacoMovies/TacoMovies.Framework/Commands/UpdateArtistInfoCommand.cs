using JSONParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Commands
{
    public class UpdateArtistInfoCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IUtils utils;
        private readonly IAuthProvider authProvider;

        public UpdateArtistInfoCommand(IMovieDbContext dbContext, IAuthProvider authProvider, IUtils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils;
            this.authProvider = authProvider;

            Validator.IsUserAuhtorised(authProvider);
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var dateOfBirth = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            var profession = (Profession)Enum.Parse(typeof(Profession), parameters[3]);
            var country = this.utils.FindCurrentCountry(parameters[4]);

            var artistToUpdate = dbContext.Artists
                                           .Where(n => n.FirstName == firstName && n.LastName == lastName)
                                           .First();

            artistToUpdate.DateOfBirth = dateOfBirth;
            artistToUpdate.Profession = profession;
            artistToUpdate.Country = country;

            dbContext.SaveChanges();
            
            return $"{artistToUpdate.FirstName} {artistToUpdate.LastName}'s info has been successfully updated!";
        }
    }
}
