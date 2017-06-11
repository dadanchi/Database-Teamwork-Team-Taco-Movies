using JSONParser;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models;

namespace TacoMovies.Framework.Commands
{
    
    public class AddAwardsCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IUtils utils;
        private readonly IAuthProvider authProvider;

        public AddAwardsCommand(IMovieDbContext dbContext, IAuthProvider authProvider, IUtils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils;
            this.authProvider = authProvider;

            Validator.IsUserAuhtorised(authProvider);
        }

        public string Execute(IList<string> parameters)
        {
            var awardName = parameters[0];

            var award = new Award
            {
                Name = awardName
            };

            dbContext.Awards.AddOrUpdate(a => a.Name, award);
            dbContext.SaveChanges();

            return $"{award.Name} has been successfully added!";
        }
    }
}
