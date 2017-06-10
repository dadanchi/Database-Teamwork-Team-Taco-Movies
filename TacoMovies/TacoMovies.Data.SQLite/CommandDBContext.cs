using System.Data.Common;
using System.Data.Entity;

namespace TacoMovies.Data.SQLite
{
    public class CommandDbContext : DbContext
    {
        public CommandDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            this.Configure();
        }

        public CommandDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            this.Configure();
        }

        private void Configure()
        {
            this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new CommandDbInitializer(modelBuilder);
            Database.SetInitializer(initializer);
        }
    }
}