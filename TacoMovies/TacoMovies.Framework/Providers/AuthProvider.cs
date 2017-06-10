using System;
using System.Linq;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models.Enums;

namespace TacoMovies.Framework.Providers
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IMovieDbContext dbContext;
        private readonly IConfigurationProvider configurationProvider;

        public AuthProvider(IMovieDbContext dbContext, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.configurationProvider = configurationProvider;
        }

        public string CurrentUsername
        {
            get
            {
                return this.configurationProvider.CurrentUser;
            }

            set
            {
                this.configurationProvider.CurrentUser = value;
            }
        }

        public bool IsAuthorized()
        {
            var authority = this.dbContext.Users
                .Where(x => x.Username == this.CurrentUsername)
                .FirstOrDefault()
                .Authorization;

            if (authority == Authorization.NormalUser)
            {
                return false;
            }

            return true;
        }

        public void LogInUser(string username, string password)
        {
            var user = dbContext.Users
                .Where(x => x.Username == username && x.Password == password)
                .FirstOrDefault();

            if (user == null)
            {
                throw new ArgumentException("Wrong username/password");
            }

            this.configurationProvider.CurrentUser = user.Username;
        }

        public void LogOut()
        {
            this.configurationProvider.CurrentUser = string.Empty;
        }
    }
}