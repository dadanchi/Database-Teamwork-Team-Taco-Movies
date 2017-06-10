using System.Collections.Generic;
using System.Text;
using TacoMovies.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly string[] AvailableCommands;

        public HelpCommand()
        {
            this.AvailableCommands = new[]
            {
                "Register",
                "Login",
                "Logout",
                "Add movie",
                //"List movies" - add it
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
