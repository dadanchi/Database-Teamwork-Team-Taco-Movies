using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.IO;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Models;
using TacoMovies.Models.Enums;

namespace JSONParser
{
    public class MovieParser 
    {
        private readonly MoviesDbContext dbContext;
        private readonly Utils utils;

        public MovieParser(MoviesDbContext dbContext, Utils utils)
        {
            this.dbContext = dbContext;
            this.utils = utils; 
        }

        public void Parse(string path)
        {
            var json = File.ReadAllText(path);

            var jArray = JArray.Parse(json);

            foreach (var jObj in jArray)
            {
                var currentCountryName = jObj["Country"].ToString();
                var currentCountry = this.utils.FindCurrentCountry(currentCountryName);

                var genreName = jObj["Genre"].ToString();
                var genre = this.utils.FindCurrentGenre(genreName);

                var directorName = jObj["Director"].ToString();
                var director = this.utils.FindCurrentArtist(directorName, Profession.Director);

                var movie = new Movie
                {
                    Name = (string)jObj["Name"],
                    Rating = (float)jObj["Rating"],
                    PublishDate = (DateTime.Parse((string)jObj["PublishDate"], new CultureInfo("en-CA"))),
                    Director = director,
                    Length = (int)jObj["Length"],
                    Coutry = currentCountry,
                    Genre = genre
                };

                var actors = jObj["Actors"];

                foreach (var actor in actors)
                {
                    var newActor = this.utils.FindCurrentArtist(actor.ToString(), Profession.Actor);
                    movie.Actors.Add(newActor);
                }

                this.dbContext.Movies.AddOrUpdate(m => new { m.Name }, movie);
            }

            this.dbContext.SaveChanges();
        }
    }
}
