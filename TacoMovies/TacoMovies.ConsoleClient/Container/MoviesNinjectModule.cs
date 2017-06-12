using JSONParser;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.ConsoleExtensions;
using TacoMovies.ConsoleExtensions.Contracts;
using TacoMovies.Contracts;
using TacoMovies.Data;
using TacoMovies.Data.Contracts;
using TacoMovies.Framework.Commands;
using TacoMovies.Framework.Core;
using TacoMovies.Framework.Factories;
using TacoMovies.Framework.Providers;

namespace TacoMovies.ConsoleClient.Container
{
    public class MoviesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IAuthProvider>().To<AuthProvider>();
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IExtendedConsoleWriter>().To<ExtendedConsoleWriter>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IMovieDbContext>().To<MoviesDbContext>().InSingletonScope();
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            this.Bind<IUtils>().To<Utils>();
        }
    }
}
