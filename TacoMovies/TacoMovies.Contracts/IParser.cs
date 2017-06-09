using System.Collections.Generic;

namespace TacoMovies.Contracts
{
    public interface IParser
    {
        IList<string> Parse(string path);
    }
}
