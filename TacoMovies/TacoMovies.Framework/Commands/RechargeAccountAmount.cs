using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Providers;

namespace TacoMovies.Framework.Commands
{
    public class RechargeAccountAmount : ICommand
    {
        private IMovieDbContext dbContext;
        private IAuthProvider authProvider;
        public RechargeAccountAmount(IMovieDbContext dbContext, IAuthProvider authProvider)
        {
            this.dbContext = dbContext;
            this.authProvider = authProvider;

            Validator.IsUserAuhtorised(authProvider);
        }
        public string Execute(IList<string> parameters)
        {
            var amount = int.Parse(parameters[0]);
            var usernameToRecharge = parameters[1];

            var user = this.dbContext.Users
                                     .Where(x => x.FirstName == usernameToRecharge)
                                     .First();

            user.Account.Ammount += amount;

            return $"{usernameToRecharge}'s account has been recharged with {amount}!";
        }
    }
}
