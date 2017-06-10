﻿using System;
using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;

namespace TacoMovies.Framework.Providers
{
    public class CommandParser : IParser
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private Validator validator;
        private IMovieDbContext dbContext;
        
        public CommandParser(IWriter writer, IReader reader, IMovieDbContext dbContext)
        {
            this.writer = writer;
            this.reader = reader;
            this.dbContext = dbContext;
            this.validator = new Validator(writer, reader);
        }

        public IList<string> Parse(string command)
        {
            switch (command.ToLower())
            {
                case "register":
                    {
                        return ParseRegisterCommand();
                    }
                case "login":
                    {
                        return ParseLoginCommand();
                    }
                case "create movie":
                    {
                        return ParseCreateMovieCommand();
                    }
                case "add artist":
                    {
                        return ParseAddArtistCommand();
                    }
                case "add award":
                    {
                        return ParseAwardCommand();
                    }
                default: return null;
            }
        }

        private IList<string> ParseAwardCommand()
        {
            var awardData = new List<string>();

            this.writer.WriteLine("Enter award name : ");
            var award = this.reader.Read();
            awardData.Add(award);

            return awardData;
        }

        private IList<string> ParseLoginCommand()
        {
            var userData = new List<string>();

            this.writer.WriteLine("Enter a username : ");
            var username = this.reader.Read();
            this.validator.ValidateUsernameOrPassword(username);
            userData.Add(username);

            this.writer.WriteLine("Enter a password : ");
            var password = this.reader.Read();
            this.validator.ValidateUsernameOrPassword(password);
            userData.Add(password);

            return userData;
        }

        private IList<string> ParseRegisterCommand()
        {
            var userData = new List<string>();
            
            this.writer.WriteLine("Enter a username : ");
            var username = this.reader.Read();
            while (!this.validator.ValidateUsernameOrPassword(username) || this.validator.IsUsernameTaken(username, this.dbContext))
            {
                username = this.reader.Read();
            }

            userData.Add(username);

            this.writer.WriteLine("Enter a password : ");
            var password = this.reader.Read();
            while (!this.validator.ValidateUsernameOrPassword(password))
            {
                password = this.reader.Read();
            }

            userData.Add(password);

            this.writer.WriteLine("Enter a first name : ");
            var firstName = this.reader.Read();
            userData.Add(firstName);

            this.writer.WriteLine("Enter a last name : ");
            var lastName = this.reader.Read();
            userData.Add(lastName);

            return userData;
        }

        private IList<string> ParseAddArtistCommand()
        {
            var artistData = new List<string>();

            this.writer.WriteLine("Enter First name : ");
            var firstName = this.reader.Read();
            artistData.Add(firstName);

            this.writer.WriteLine("Enter Last name : ");
            var lastName = this.reader.Read();
            artistData.Add(lastName);

            this.writer.WriteLine("Enter date of birth : ");
            var dateOfBirth = this.reader.Read();
            artistData.Add(dateOfBirth);

            this.writer.WriteLine("Enter profession : ");
            var profession = this.reader.Read();
            artistData.Add(profession);

            this.writer.WriteLine("Enter country : ");
            var country = this.reader.Read();
            artistData.Add(country);

            this.writer.WriteLine("Enter award (if any) : ");
            var award = this.reader.Read();
            artistData.Add(award);

            return artistData;
        }

        private List<string> ParseCreateMovieCommand()
        {
            var movieData = new List<string>();

            this.writer.WriteLine("Enter movie name : ");
            var movieName = this.reader.Read();
            movieData.Add(movieName);

            this.writer.WriteLine("Enter rating : ");
            var rating = this.reader.Read();
            movieData.Add(rating);

            this.writer.WriteLine("Enter publish date : ");
            var date = this.reader.Read();
            movieData.Add(date);

            this.writer.WriteLine("Enter length : ");
            var length = this.reader.Read();
            movieData.Add(length);

            this.writer.WriteLine("Enter director : ");
            var director = this.reader.Read();
            movieData.Add(director);

            this.writer.WriteLine("Enter country : ");
            var country = this.reader.Read();
            movieData.Add(country);

            this.writer.WriteLine("Enter genre");
            var genre = this.reader.Read();
            movieData.Add(genre);

            return movieData;

        }
    }
}
