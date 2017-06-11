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

namespace TacoMovies.Framework.Commands
{
    public class UpdateDirectorInfoCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IUtils utils;
        private readonly IAuthProvider authProvider;

        public UpdateDirectorInfoCommand(IMovieDbContext dbContext, IUtils utils, IAuthProvider authProvider)
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
            var dateOfBirth = parameters[2];
            var country = parameters[3];

            var directorToUpdate = dbContext.Artists
                                           .Where(n => n.FirstName == firstName && n.LastName == lastName)
                                           .First();

            directorToUpdate.DateOfBirth = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            directorToUpdate.Country = this.utils.FindCurrentCountry(country);

            dbContext.SaveChanges();

            return $"{directorToUpdate.FirstName} {directorToUpdate.LastName}'s info has been successfully updated!";
        }
    }
}
