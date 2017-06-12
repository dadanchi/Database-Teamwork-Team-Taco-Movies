using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Data.Postgre;
using TacoMovies.Models;

namespace TacoMovies.Framework.Helpers
{
    public static class AccountCreator
    {
        private static MoviesDbContext postgre = new MoviesDbContext();
        static AccountCreator()
        {

        }

        public static Account CreateAccount(User user)
        {
            var account = new Account
            {
                AccountNumber = RandomStringGenerator.GenerateRandomString(8),
                Ammount = 100,
                User = user
            };

            postgre.Account.Add(account);
            postgre.SaveChanges();

            return account;
        }
    }
}
