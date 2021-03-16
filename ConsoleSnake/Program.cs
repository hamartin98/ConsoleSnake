using System;

namespace ConsoleSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowWelcomeScreen();

            while(!Console.KeyAvailable)
            {
                
            }

            Game game = new Game();
            game.StartGame();
        }

        private static void ShowWelcomeScreen()
        {
            string welcomeScreen = FileIO.readToString("Screens/welcomeScreen.txt");
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine(welcomeScreen);
        }
    }
}
