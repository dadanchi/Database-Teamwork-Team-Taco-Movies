namespace TacoMovies.ConsoleExtensions.Contracts
{
    public interface IProgressBar
    {
        void Dispose();
        void Report(double value);
    }
}