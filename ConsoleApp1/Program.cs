
using ConsoleApp1;
using GameCore.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInputService = new ConsoleUserInput();
            RunGame run = new RunGame(userInputService);
            run.PlayGame();
        }
    }
}



