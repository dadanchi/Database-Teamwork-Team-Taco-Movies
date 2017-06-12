using System.Drawing;
using Colorful;
using TacoMovies.ConsoleExtensions.Contracts;

namespace TacoMovies.ConsoleExtensions
{
    public class ConsoleGUI : IConsoleGUI
    {
        public void SetUp()
        {
            Console.SetWindowSize((int)(Console.LargestWindowWidth * 0.5),
                (int)(Console.LargestWindowHeight * 0.8));
            Console.BackgroundColor = Color.White;
        }
    }
}