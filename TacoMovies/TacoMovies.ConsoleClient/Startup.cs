﻿using JSONParser;
using Ninject;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using TacoMovies.ConsoleClient.Container;
using TacoMovies.ConsoleExtensions;
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
            var postgre = new TacoMovies.Data.Postgre.MoviesDbContext();

            // StartDemoUseSqlite();
            // StartDemoUsePostgre();
            // StartDemoReportService();
            StartDemoExtendedConsole();

            //var parser = new MasterParser(dbContext);
            //parser.Parse("../../../ExternalData/Countries.json", "../../../ExternalData/artist.json",
            //"../../../ExternalData/movies.json");
            var kernel = new StandardKernel(new MoviesNinjectModule());

            var engine = kernel.Get<IEngine>();
            engine.Start();


            //var account = new Account
            //{
            //    AccountNumber = "uk123456",
            //    User = user,
            //    Ammount = 100
            //};

            //postgre.Users.Add(user);
           // postgre.Account.Add(account);
           // dbContext.Account.Add(account);

               // postgre.SaveChanges();
              // dbContext.SaveChanges();














        }

        private static void StartDemoExtendedConsole()
        {
            new ConsoleGUI().SetUp();
            var extendedWriter = new ExtendedConsoleWriter(new ConsoleWriter());
            extendedWriter.WriteAscii("Taco Movies");
            extendedWriter.WriteProgress("Query from DB ...");

            extendedWriter.WriteLine("Movies blah, blah");
            extendedWriter.WriteLine("ddd");
        }

        private static void StartDemoReportService()
        {
            var reportService = new ReportServiceProvider("../../../ExternalData/Reports/TacoActorsReport.pdf");
            reportService.Start();
        }

        private static void StartDemoUsePostgre()
        {
            var dbContext = new Data.Postgre.MoviesDbContext();

            dbContext.Set<Country>().Add(new Country
            {
                Name = "Bulgaria"
            });

            dbContext.SaveChanges();

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
                context.Set<Command>().Add(new Command
                {
                    ExecutionTime = DateTime.Now,
                    Text = "Add movie 1"
                });

                context.Set<Command>().Add(new Command
                {
                    ExecutionTime = DateTime.Now,
                    Text = "Add movie 2"
                });

                context.SaveChanges();

                foreach (var cmd in context.Set<Command>())
                {
                    Console.WriteLine(cmd.Id + "---" + cmd.Text);
                }
            }
        }
    }
}
