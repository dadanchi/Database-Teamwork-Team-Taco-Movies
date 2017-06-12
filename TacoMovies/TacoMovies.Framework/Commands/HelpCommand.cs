using System.Collections.Generic;
using System.Text;
using TacoMovies.Contracts;

namespace TacoMovies.Framework.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly string[] AvailableCommands;
        private readonly string[] UserCommands;
        private readonly string[] AdminCommand;
        private readonly IAuthProvider authProvider;

        public HelpCommand(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;

            this.AvailableCommands = new[]
            {
                "Register",
                "Login",
                "Logout",
                "Search movie by actors",
                "Search actors by movie"
            };

            this.UserCommands = new[]
             {
                "list my movies",
                "Add movie",
            };

            this.AdminCommand = new[]
            {
                "Add artist",
                "Add award",
                "Create movie",
                "Update artist info",
               "search movie by actors",
               "search actors by movie",
               "list all artists"

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

            if (this.authProvider.CurrentUsername != string.Empty)
            {
                foreach (var command in UserCommands)
                {
                    result.AppendLine(command);
                }
            }

            if (this.authProvider.IsAuthorized())
            {
                foreach (var command in AdminCommand)
                {
                    result.AppendLine(command);
                }
            }

            result.AppendLine("--------------------");

            return result.ToString();
        }
    }
}
