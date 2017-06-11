using JSONParser;
using Ninject;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using TacoMovies.ConsoleClient.Container;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Data.SQLite;
using TacoMovies.Data.SQLite.Entity;
using TacoMovies.Framework.Core;
using TacoMovies.Framework.Factories;
using TacoMovies.Framework.Providers;
using TacoMovies.JSONParser;
using TacoMovies.Models;
using TacoMovies.Models.Enums;
using TacoMovies.ReportService;

namespace TacoMovies.ConsoleClient
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var dbContext = new MoviesDbContext();

            // StartDemoUseSqlite();
            // StartDemoUsePostgre();
            // StartDemoReportService();

            //var parser = new MasterParser(dbContext);
            //parser.Parse("../../../ExternalData/Countries.json", "../../../ExternalData/artist.json",
            //"../../../ExternalData/movies.json");
            var kernel = new StandardKernel(new MoviesNinjectModule());

            var engine = kernel.Get<IEngine>();
            engine.Start();

            //var actorsInMovie = dbContext.Movies
            //                 .Where(m => m.Name == "Inception")
            //                 .SelectMany(m => m.Actors)
            //                 .ToList();

            //foreach (var actor in actorsInMovie)
            //{
            //    Console.WriteLine(actor.FirstName);
            //}


            //var user = dbContext.Users
            //                  .Where(n => n.Username == "Pesho")
            //                  .First();

            //foreach (var item in user.Movies)
            //{
            //    Console.WriteLine(item.Name);
            //}













        }

        private static void StartDemoReportService()
        {
            var reportService = new ReportServiceProvider("../../../ExternalData/Reports/TacoActorsReport.pdf");
            reportService.Start();
        }

        private static void StartDemoUsePostgre()
        {
            var dbContext = new Data.Postgre.MoviesDbContext();

            /*dbContext.Set<Country>().Add(new Country
            {
                Name = "Bulgaria"
            });

            dbContext.SaveChanges();*/

            var result = dbContext.Countries
                .Where(c => c.Name == "Bulgaria")
                .Select(x => x.Name)
                .ToList();

            Console.WriteLine(string.Join(",", result));
        }

        private static void StartDemoUseSqlite()
        {
            Console.WriteLine("Starting Demo SQLite: ");
            Console.WriteLine(string.Empty);

            using (var context = new CommandDbContext("CommandsSQLiteDB"))
            {
                /*context.Set<Command>().Add(new Command
                {
                    ExecutionTime = DateTime.Now,
                    Text = "Add movie 1"
                });

                context.Set<Command>().Add(new Command
                {
                    ExecutionTime = DateTime.Now,
                    Text = "Add movie 2"
                });

                context.SaveChanges();*/

                foreach (var cmd in context.Set<Command>())
                {
                    Console.WriteLine(cmd.Id + "---" + cmd.Text);
                }
            }
        }
    }
}
