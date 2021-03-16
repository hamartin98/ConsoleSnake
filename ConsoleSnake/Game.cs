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
            speed = 500;

            InitConsole();
        }

        // Can be called from outside of the class to start the game
        public void StartGame()
        {
            inGame = true;
            PlayGame();
        }

        // Plays the game until the snake hits itself, an obstacle or the edge of the map
        // Reads input from Console, then change behavior based on the input
        private void PlayGame()
        {
            do
            {
                if (Console.KeyAvailable)
                {
                    char input = Console.ReadKey(true).KeyChar;
                    snake.SetDirection(Direction.getDirectionFromChar(input));
                }

                if (snake.Move() || CheckHit()) // Move the snake and check for impact
                {
                    inGame = false;
                    break;
                }

                PrintMap();
                System.Threading.Thread.Sleep(speed);

            }
            while (inGame);
        }

        // Checks snake collision with the edge of the map, obstacles and istself
        // return true if a hit occurs
        private bool CheckHit()
        {
            return CheckEdgeHit();
        }

        // Returns true if the snake hits the edge of the map
        private bool CheckEdgeHit()
        {
            Point headPos = snake.HeadPos;
            int posX = headPos.X;
            int posY = headPos.Y;

            if (posX <= 0 || posX == mapWidth || posY <= 0 || posY == mapHeight)
            {
                return true;
            }

            return false;
        }

        // Initialize the console window
        // Sets the output encoding, the cursor visibility, the height and width of the window
        private void InitConsole()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WindowHeight = mapHeight;
            Console.WindowWidth = mapWidth;
        }

        // Displays everything on the console
        private void PrintMap()
        {
            Console.Clear();
            PrintSnake();
        }

        // Prints the body parts of the snake to the console
        private void PrintSnake()
        {
            foreach (Point pos in snake.Body)
            {
                snake.BodyPart.PrintToScreen(pos);
            }
        }
    }
}
