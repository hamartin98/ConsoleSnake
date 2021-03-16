using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    // Represents the game itself
    // Manages game loop, snake, obstacles
    class Game
    {
        private bool inGame; // Stores the current state of the game, true if the game is on
        private Snake snake; // Represents the snake that can be contrelled by the player
        List<Obstacle> obstalces; // Stores all of the obstacles on the map
        private int speed; // stores the speed of the game in milliseconds, the time interval to refresh the screen
        private int mapWidth;
        private int mapHeight;

        public Game()
        {
            inGame = false;
            snake = new Snake();
            obstalces = new List<Obstacle>();
            mapWidth = 120;
            mapHeight = 40;

            InitConsole();
        }

        // Can be called from outside of the class to start the game
        public void StartGame()
        {
            inGame = true;
            PlayGame();
        }

        // Plays the game until a the snake hits itself, an obstacle or the edge of the map
        // Reads input from Console, then change behavior based on the input
        private void PlayGame()
        {

        }

        // Checks snake collision with the edge of the map, obstacles and istself
        private bool CheckImpact()
        {
            return false;
        }

        // Initialize the console window
        // Sets the output encoding, the cursor visibility, the height and width of the window
        private void InitConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WindowHeight = mapHeight;
            Console.WindowWidth = mapWidth;
        }
    }
}
