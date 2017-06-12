using JSONParser;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;
using TacoMovies.Models;
using TacoMovies.Models.Enums;


namespace TacoMovies.Framework.Commands
{
    public class CreateMovieCommand : ICommand
    {
        private readonly IMovieDbContext dbContext;
        private readonly IUtils utils;
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IAuthProvider authProvider;

        public CreateMovieCommand(IMovieDbContext dbContext, IAuthProvider authProvider, IReader reader, IWriter writer, IUtils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils;
            this.writer = writer;
            this.reader = reader;
            this.authProvider = authProvider;

            Validator.IsUserAuhtorised(authProvider);
        }

        public string Execute(IList<string> parameters)
        {
            var movieName = parameters[0];
            var rating = float.Parse(parameters[1]);
            var publishDate = DateTime.Parse(parameters[2], new CultureInfo("en-CA"));
            var length = int.Parse(parameters[3]);
            var directorToAdd = utils.FindCurrentArtist(parameters[4], Profession.Director);
            var countryToAdd = utils.FindCurrentCountry(parameters[5]);
            var genreToAdd = utils.FindCurrentGenre(parameters[6]);

            var movie = new Movie
            {
                Name = movieName,
                Rating = rating,
                PublishDate = publishDate,
                Length = length,
                Director = directorToAdd,
                Coutry = countryToAdd,
                Genre = genreToAdd
            };

            while (true)
            {
                this.writer.WriteLine("Enter actor (or type end to terminate) : ");
                var input = this.reader.Read();

                if (input.ToLower() == "end")
                {
                    break;
                }
                else if (string.IsNullOrEmpty(input))
                {
                    this.writer.WriteLine("Enter an actor or terminate process");
                }

                var actorToAdd = utils.FindCurrentArtist(input, Profession.Actor);

                movie.Actors.Add(actorToAdd);
            }

            dbContext.Movies.AddOrUpdate(m => m.Name, movie);

            dbContext.SaveChanges();

            return $"{movie.Name} has been successfully created!";
        }
    }
}