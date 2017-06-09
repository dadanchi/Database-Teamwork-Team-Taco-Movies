using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data;

namespace TacoMovies.Framework.Core
{
    public class Engine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IParser parser;
        private readonly ICommandFactory commandFactory;
        private readonly MoviesDbContext dbContext;

        public Engine(IParser parser, IWriter writer, IReader reader, ICommandFactory commandFactory, MoviesDbContext dbContext)
        {
            this.writer = writer;
            this.reader = reader;
            this.commandFactory = commandFactory;
            this.parser = parser;
            this.dbContext = dbContext;
        }

        public void Start()
        {
            while (true)
            {
                var commandAsString = this.reader.Read();

                if (commandAsString.ToLower() == "exit")
                {
                    break;
                }
                var command = this.commandFactory.GetCommand(commandAsString, dbContext);
                var parameters = this.parser.Parse(commandAsString);

                command.Execute(parameters);
            }
        }
    }
}
