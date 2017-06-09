using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using TacoMovies.Data;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace JSONParser
{
    public class MovieParser
    {
        private readonly MoviesDbContext dbContext;

        public MovieParser(MoviesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Parse()
        {
            var json = File.ReadAllText("../../../ExternalData/movies.json");

            var jArray = JArray.Parse(json);

            foreach (var jObj in jArray)
            {
                var currentCountryName = jObj["Country"].ToString();
                var currentCountry = FindCurrentCountry(currentCountryName);

                var genreName = jObj["Genre"].ToString();
                var genre = FindCurrentGenre(genreName);

                var directorName = jObj["Director"].ToString();
                var director = FindCurrentArtist(directorName, Profession.Director);

                var actors = jObj["Actors"];
                ICollection<Artist> actorCollection = new List<Artist>();

                foreach (var actor in actors)
                {
                    var newActor = FindCurrentArtist(actor.ToString(), Profession.Actor);
                    actorCollection.Add(newActor);
                }


                var movie = new Movie
                {
                    Name = (string)jObj["Name"],
                    Rating = (float)jObj["Rating"],
                    PublishDate = (DateTime.Parse((string)jObj["PublishDate"], new CultureInfo("en-CA"))),
                    Director = director,
                    Length = (int)jObj["Length"],
                    Coutry = currentCountry,
                    Actors = actorCollection,
                    Genre = genre
                };


                Console.WriteLine(movie.Name);
                Console.WriteLine(movie.Rating);
                Console.WriteLine(movie.PublishDate);
                Console.WriteLine(movie.Director.FirstName);
                Console.WriteLine(movie.Genre);
                Console.WriteLine(movie.Coutry.Name);
                Console.WriteLine(string.Join(" ", movie.Actors));
                Console.WriteLine();


                this.dbContext.Movies.AddOrUpdate(m => new { m.Name }, movie);

            }

            this.dbContext.SaveChanges();

        }

        private Country FindCurrentCountry(string currentCountryName)
        {
            var currentCountry = this.dbContext.Countries
                     .Where(c => c.Name == currentCountryName)
                     .FirstOrDefault();
        
            return currentCountry;
        }

        private Genre FindCurrentGenre(string genreName)
        {
            var genre = this.dbContext.Genres
                     .Where(c => c.Name == genreName)
                     .FirstOrDefault();

            return genre;
        }

        private Artist FindCurrentArtist(string actorName, Profession profession)
        {
            var artistAsString = actorName.ToString().Split(' ');
            var firstName = artistAsString[0];
            var lastName = artistAsString[1];

            var artist = this.dbContext.Artists
                .Where(x => x.FirstName == firstName && x.LastName == lastName && x.Profession == profession)
                .FirstOrDefault();

            if (artist == null)
            {
                var newArtist = new Artist()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Profession = profession,
                    // TODO - ask marto
                    DateOfBirth = new DateTime(2000, 1, 1)
                };

                dbContext.Artists.Add(newArtist);

                return newArtist;
            }

            return artist;
        }
    }
}
