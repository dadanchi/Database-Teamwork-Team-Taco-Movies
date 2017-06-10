using System.Data.Entity;

namespace TacoMovies.Data.Sqlite
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            ConfigureCommandEntity(modelBuilder);
        }

        private static void ConfigureCommandEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>().ToTable("Base.Command")
                .HasRequired(t => t.Text);
        }
    }
}