using System;
using SQLite.CodeFirst;

namespace TacoMovies.Data.SQLite.Entity
{
    public class Command
    {
        [Autoincrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
