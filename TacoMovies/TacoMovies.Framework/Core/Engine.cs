using System;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.Framework.Core
{
    public class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IParser parser;
        private readonly ICommandFactory commandFactory;
        private readonly IMovieDbContext dbContext;
        private readonly IAuthProvider authProvider;
        private User currentUser;


        public Engine(IParser parser, IWriter writer, IReader reader, ICommandFactory commandFactory,
              IMovieDbContext dbContext, User user, IAuthProvider authProvider)
        {
            this.writer = writer;
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.dbContext = dbContext;
            this.parser = parser;
            this.currentUser = user;
            this.authProvider = authProvider;
        }

        public void Start()
        {
            var terminateCommand = "exit";

            while (true)
            {
                var commandAsString = this.reader.Read();

                if (commandAsString.ToLower() == terminateCommand)
                {
                    break;
                }

                try
                {
                    var command = this.commandFactory.GetCommand(commandAsString, this.dbContext, this.authProvider, this.currentUser);
                    var parameters = this.parser.Parse(commandAsString);                   
                    var resultMessage = command.Execute(parameters);

                    this.writer.WriteLine(resultMessage);
                }

                catch(Exception e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
    }
}
