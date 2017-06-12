using System.Drawing;
using TacoMovies.Contracts;

namespace TacoMovies.ConsoleExtensions.Contracts
{
    public interface IExtendedConsoleWriter : IWriter
    {
        void WriteAscii(string message, Color color);
        void WriteProgress(string message, Color color);
        void WriteColor(string message, Color color);
    }
}