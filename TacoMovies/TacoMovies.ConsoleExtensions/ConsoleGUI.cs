using System.Drawing;
using Colorful;
using TacoMovies.ConsoleExtensions.Contracts;

namespace TacoMovies.ConsoleExtensions
{
    public class ConsoleGUI : IConsoleGUI
    {
        public void SetUp()
        {
            Console.SetWindowSize((int)(Console.LargestWindowWidth * 0.7), 
                (int)(Console.LargestWindowHeight * 0.7));
            Console.BackgroundColor = Color.White;
            Console.Clear();
        }
    }
}