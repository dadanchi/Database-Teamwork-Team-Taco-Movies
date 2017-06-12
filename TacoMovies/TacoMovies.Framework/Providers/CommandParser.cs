using System;
using System.Collections.Generic;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Helpers;

namespace TacoMovies.Framework.Providers
{
    public class CommandParser : IParser
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private IMovieDbContext dbContext;
        
        public CommandParser(IWriter writer, IReader reader, IMovieDbContext dbContext)
        {
            this.writer = writer;
            this.reader = reader;
            this.dbContext = dbContext;
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
                case "add movie":
                    {
                        return ParseAddMovieCommand();
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
                case "update artist info":
                    {
                        return ParseUpdateArtistInfo();
                    }
                case "search movie by artist":
                    {
                        return ParseSearchMovieByArtist();
                    }
                case "search actors by movie":
                    {
                        return ParseSearchActorsByMovie();
                    }
                case "recharge account":
                    {
                        return ParseRechargeMyAccountAmount();
                    }
                default: return null;
            }
        }

        private IList<string> ParseRechargeMyAccountAmount()
        {
            var rechargeData = new List<string>();

            this.writer.WriteLine("Enter required amount : ");
            var amount = this.reader.Read();
            rechargeData.Add(amount);

            this.writer.WriteLine("Enter username whose account to recharge : ");
            var username = this.reader.Read();
            rechargeData.Add(username);

            return rechargeData;
        }

        private IList<string> ParseSearchActorsByMovie()
        {
            var movieName = new List<string>();

            this.writer.WriteLine("Enter movie's name : ");
            var movie = this.reader.Read();
            movieName.Add(movie);

            return movieName;
        }

        private IList<string> ParseSearchMovieByArtist()
        {
            var artistNames = new List<string>();

            this.writer.WriteLine("Enter artist's first name : ");
            var firstName = this.reader.Read();
            artistNames.Add(firstName);

            this.writer.WriteLine("Enter artist's last name : ");
            var lastName = this.reader.Read();
            artistNames.Add(lastName);

            return artistNames;
        }

        private IList<string> ParseUpdateArtistInfo()
        {
            var artistInfo = new List<string>();


            this.writer.WriteLine("Enter artist's first name : ");
            var firstName = this.reader.Read();
            artistInfo.Add(firstName);


            this.writer.WriteLine("Enter artist's last name : ");
            var lastName = this.reader.Read();
            artistInfo.Add(lastName);

            this.writer.WriteLine("Enter date of birth : ");
            var birthDate = this.reader.Read();
            artistInfo.Add(birthDate);

            this.writer.WriteLine("Enter profession : ");
            var profession = this.reader.Read();
            artistInfo.Add(profession);

            this.writer.WriteLine("Enter country : ");
            var country = this.reader.Read();
            artistInfo.Add(country);

            return artistInfo;
        }

        private IList<string> ParseAwardCommand()
        {
            var awardData = new List<string>();

            this.writer.WriteLine("Enter award name : ");
            var award = this.reader.Read();
            awardData.Add(award);

            return awardData;
        }

        private IList<string> ParseAddMovieCommand()
        {
            var userData = new List<string>();

            this.writer.WriteLine("Enter the name of the movie you want to add : ");
            var movieTitle = this.reader.Read();

            if (!Validator.DoesMovieExist(movieTitle, this.dbContext, this.writer))
            {
                throw new Exception("There is no movie with such name in the database.");
            }

            userData.Add(movieTitle);

            return userData;
        }

        private IList<string> ParseLoginCommand()
        {
            var userData = new List<string>();

            this.writer.WriteLine("Enter a username : ");
            var username = this.reader.Read();
            Validator.ValidateUsernameOrPassword(username, this.writer);
            userData.Add(username);

            this.writer.WriteLine("Enter a password : ");
            var encryptedPassword = PasswordEncrypter.GetConsolePassword(writer);
            Validator.ValidateUsernameOrPassword(encryptedPassword, this.writer);
            userData.Add(encryptedPassword);

            return userData;
        }

        private IList<string> ParseRegisterCommand()
        {
            var userData = new List<string>();

            this.writer.WriteLine("Enter a username : ");
            var username = this.reader.Read();
            while (!Validator.ValidateUsernameOrPassword(username, this.writer) || Validator.IsUsernameTaken(username, this.dbContext, writer))
            {
                username = this.reader.Read();
            }

            userData.Add(username);

            this.writer.WriteLine("Enter a password : ");
            var encryptedPassword = PasswordEncrypter.GetConsolePassword(writer);
            while (!Validator.ValidateUsernameOrPassword(encryptedPassword, this.writer))
            {
                encryptedPassword = this.reader.Read();
            }

            userData.Add(encryptedPassword);

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