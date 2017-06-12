using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TacoMovies.Contracts;

namespace TacoMovies.Framework.Helpers
{
    public static class PasswordEncrypter
    {
         static PasswordEncrypter()
        {

        }

        internal static string GetConsolePassword(IWriter writer)
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    writer.WriteLine("");
                    break;
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        writer.Write("\b\0\b");
                        sb.Length--;
                    }

                    continue;
                }

                writer.Write("*");
                sb.Append(cki.KeyChar);
            }

            return sb.ToString();
        }
    }
}
