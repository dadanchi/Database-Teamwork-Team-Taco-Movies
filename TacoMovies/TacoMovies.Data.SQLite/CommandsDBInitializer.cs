using System.Data.Entity;
using SQLite.CodeFirst;

namespace TacoMovies.Data.SQLite
{
    public class CommandsDBInitializer : SqliteDropCreateDatabaseAlways<CommandsDbContext>
    {
        public CommandsDBInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder)
        { }

        protected override void Seed(CommandsDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}