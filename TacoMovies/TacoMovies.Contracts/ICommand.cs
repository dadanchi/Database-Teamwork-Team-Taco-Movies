using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoMovies.Contracts
{
    public interface ICommand
    {
        void Execute(IList<string> parameters);
    }
}
