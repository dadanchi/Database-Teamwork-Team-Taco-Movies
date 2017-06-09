using JSONParser;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using TacoMovies.Data;
using TacoMovies.JSONParser;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();

            //var parser = new MasterParser(dbContext);
            //parser.Parse();

            //var user = new User()
            //{
            //    Username = "goshko",
            //    Password = "goshko",
            //    FirstName = "goshko",
            //    LastName = "goshkov",
            //    Authorization = Authorization.Admin
            //};

            //dbContext.Users.AddOrUpdate(user);
            var movie = dbContext.Movies
                               .Where(x => x.Id == 2)
                               .First();



            var goshko = dbContext.Users
                .Where(x => x.Username == "goshko")
                .First();

            goshko.Movies.Add(movie);


            //dbContext.SaveChanges();

            Console.WriteLine(goshko.Movies.First());
        }
    }
}
