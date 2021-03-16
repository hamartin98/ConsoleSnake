﻿using System;
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
        List<Obstacle> obstacles; // Stores all of the obstacles on the map
        private int speed; // stores the speed of the game in milliseconds, the time interval to refresh the screen
        private int mapWidth;
        private int mapHeight;
        StringBuilder line;
        private int score;

        public Game()
        {
            inGame = false;
            snake = new Snake();
            obstacles = new List<Obstacle>();
            mapWidth = 120;
            mapHeight = 40;
            speed = 500;
            score = 0;

            InitConsole();

            line = new StringBuilder();
            for (int i = 0; i < mapWidth; i++)
            {
                line.Append('-');
            }

            Food apple = new Food(Point.GetRandom(mapWidth, mapHeight));
            obstacles.Add(apple);
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

            ShowEndScreen();
        }

        // Checks snake collision with the edge of the map, obstacles and istself
        // return true if a hit occurs
        private bool CheckHit()
        {
            return CheckEdgeHit() || CheckObstacleHit();
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

        // Check hit with every obstacle on the map
        // If the snake hit something that cannot be eaten returns true
        private bool CheckObstacleHit()
        {
            Point headPos = snake.HeadPos;
            foreach(var obstacle in obstacles)
            {
                if(obstacle.Position.Equals(headPos))
                {
                    if(obstacle.IsDestroyable) // the snake ate something, it grows and gets score
                    {
                        snake.Grow();
                        score += obstacle.Score;
                        obstacles.Remove(obstacle);
                        obstacles.Add(new Food(new Point(Point.GetRandom(mapWidth, mapHeight))));
                        break;
                    }

                    return true;
                }
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
            PrintObstacles();

            Console.SetCursorPosition(0, mapHeight);
            Console.Write(line.ToString());
        }

        // Prints the body parts of the snake to the console
        private void PrintSnake()
        {
            foreach (Point pos in snake.Body)
            {
                snake.BodyPart.PrintToScreen(pos);
            }
        }

        private void PrintObstacles()
        {
            foreach(var obstacle in obstacles)
            {
                obstacle.Img.PrintToScreen(obstacle.Position);
            }
        }

        private void ShowEndScreen()
        {
            Console.Clear();
            Console.WriteLine($"Score: {score}");
        }
    }
}
