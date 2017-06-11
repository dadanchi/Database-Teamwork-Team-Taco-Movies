using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class LoggedInUserHelpCommand : ICommand
    {
        private readonly string[] AvailableCommands;

        public LoggedInUserHelpCommand()
        {
            this.AvailableCommands = new[]
            {
                "add artist (admin only)",
                "add award (admin only)",
                "add movie",
                "create movie (admin only)",
               "update artist info (admin only)",
               "search actors by movie",
               "search movies by actor"
            };
        }

        public string Execute(IList<string> parameters)
        {
            var result = new StringBuilder();

            result.AppendLine("Available commands: ");
            result.AppendLine("--------------------");

            foreach (var command in AvailableCommands)
            {
                result.AppendLine(command);
            }

            result.AppendLine("--------------------");

            return result.ToString();
        }
    }
}

