namespace TacoMovies.Contracts
{
    public interface IConfigurationProvider
    {
        string CurrentUser { get; set; }
    }
}
