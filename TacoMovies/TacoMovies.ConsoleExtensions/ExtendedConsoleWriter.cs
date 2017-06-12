using System;
using System.Drawing;
using System.Threading;
using TacoMovies.ConsoleExtensions.Contracts;
using TacoMovies.Contracts;
using Console = Colorful.Console;

namespace TacoMovies.ConsoleExtensions
{
    public class ExtendedConsoleWriter : IExtendedConsoleWriter, IWriter
    {
        private readonly IWriter writer;

        public ExtendedConsoleWriter(IWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException($"The writer cannot be null");
            }

            this.writer = writer;
        }

        public void Write(string message)
        {
            this.writer.Write(message);
        }

        public void WriteLine(string message)
        {
            this.writer.WriteLine(message);
        }

        public void WriteAscii(string message)
        {
            Console.WriteAscii(message, Color.Crimson);
        }

        public void WriteProgress(string message)
        {
            Console.Write(message, Color.Aqua);
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 50; i++)
                {
                    progress.Report((double)i / 50);
                    Thread.Sleep(20);
                }
            }

            Console.WriteLine("Done.");
        }
    }
}
