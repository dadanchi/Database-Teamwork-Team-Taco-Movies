using JSONParser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class UpdateDirectorInfoCommand : ICommand
    {
        private IMovieDbContext dbContext;
        private Utils utils;

        public UpdateDirectorInfoCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.utils = new Utils(dbContext);
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
