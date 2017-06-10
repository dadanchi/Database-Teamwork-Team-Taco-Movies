using System;
using SQLite.CodeFirst;

namespace TacoMovies.Data.SQLite
{
    public class Command
    {
        [Autoincrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}