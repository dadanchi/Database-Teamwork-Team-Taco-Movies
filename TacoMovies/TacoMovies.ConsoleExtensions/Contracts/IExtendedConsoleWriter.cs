using TacoMovies.Contracts;

namespace TacoMovies.ConsoleExtensions.Contracts
{
    public interface IExtendedConsoleWriter : IWriter
    {
        void WriteAscii(string message);
        void WriteProgress(string message);
    }
}