namespace TacoMovies.Contracts
{
    public interface IAuthProvider
    {
        string CurrentUsername { get; set; }

        bool IsAuthorized();

        void LogInUser(string username, string password);

        void LogOut();
    }
}
