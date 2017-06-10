using Ninject;
using System;
using TacoMovies.Contracts;
using TacoMovies.Data.Contracts;
using TacoMovies.Models;

namespace TacoMovies.ConsoleClient.Container
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(string commandAsString, IMovieDbContext dbContext, IAuthProvider authProvider, User user)
        {
            return this.kernel.Get<ICommand>(commandAsString);
        }
    }
}
