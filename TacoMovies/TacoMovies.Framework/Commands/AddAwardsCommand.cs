using JSONParser;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Framework.Commands
{
    
    public class AddAwardsCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly Utils utils;

        public AddAwardsCommand(IMovieDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.utils = new Utils(dbContext);
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
