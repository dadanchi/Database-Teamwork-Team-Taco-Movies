using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Framework.Factories;
using TacoMovies.Models;

namespace TacoMovies.Framework.Providers
{
    public class CommandParser : IParser
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private Validator validator;

        public CommandParser(IWriter writer, IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
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
                default: return null;
            }
        }

        private IList<string> ParseRegisterCommand()
        {
            var userData = new List<string>();

            this.writer.Write("Enter a username : ");
            var username = this.reader.Read();
            this.validator.ValidateUsernameOrPassword(username);
            userData.Add(username);

            this.writer.Write("Enter a password : ");
            var password = this.reader.Read();
            this.validator.ValidateUsernameOrPassword(password);
            userData.Add(password);

            this.writer.Write("Enter a first name : ");
            var firstName = this.reader.Read();
            userData.Add(firstName);

            this.writer.Write("Enter a last name : ");
            var lastName = this.reader.Read();
            userData.Add(lastName);

            return userData;
        }
    }
}
