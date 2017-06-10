using System;
using System.Data.Entity;
using SQLite.CodeFirst;

namespace TacoMovies.Data.SQLite
{
    public class CommandDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<CommandDbContext>
    {
        public CommandDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public CommandDbInitializer(DbModelBuilder modelBuilder, Type historyEntityType) : base(modelBuilder, historyEntityType)
        {
        }

        protected override void Seed(CommandDbContext context)
        {
            // Here you can seed your core data if you have any.
        }
    }
}