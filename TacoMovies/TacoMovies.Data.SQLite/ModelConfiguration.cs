using System.Data.Entity;
using TacoMovies.Data.SQLite.Entity;

namespace TacoMovies.Data.SQLite
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            CongigureCommandEntity(modelBuilder);
        }

        private static void CongigureCommandEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>();
        }
    }
}