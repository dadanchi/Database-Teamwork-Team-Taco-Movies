using System.Configuration;
using TacoMovies.Contracts;

namespace TacoMovies.ConsoleClient
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string CurrentUser
        {
            get
            {
                return ConfigurationManager.AppSettings["currentUsername"];
            }

            set
            {
                ConfigurationManager.AppSettings["currentUsername"] = value;
            }
        }
    }
}
