using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    // Contains all the functionality and data of the snake
    class Snake
    {
        private LinkedList<Point> body;
        public LinkedList<Point> Body { get => body; } // Stores every part's coordinates of the snake's body in a linked list
        private Direction direction; // The direction where the snake moves
        public Point HeadPos { get; }// The position of the snake's head
        public Image BodyPart { get; } // The Image object that represents the snake's body part on the console

        public Snake()
        {
            direction = new Direction(1, 0);
            BodyPart = new Image('■', ConsoleColor.Green);
            HeadPos = new Point(5, 1);
            InitBody();
        }

        // Initializes the body parts
        private void InitBody()
        {
            body = new LinkedList<Point>();
            
            for (int x = 5; x > 0; x--)
            {
                body.AddLast(new Point(x, 1));
            }
        }

        // Sets the snake's direction
        // If the given direction is null, the direction remains the previous
        public void SetDirection(Direction dir)
        {
            if(dir != null && dir != direction)
            {
                direction = dir;
            }
        }

        // Moves the snake based on the direction
        // Returns true if the Snake hits itself
        public bool Move()
        {
            HeadPos.ModByDirection(direction); // Modify the head's position by the direction
            
            if(body.Contains(HeadPos)) // the Snake hit itself
            {
                return true;
            }

            UpdateBody(); // Update the snake's body

            return false;
        }

        // Update the snake's body after movement
        // Adds the head position to the front of the body
        // Removes the last element
        private void UpdateBody()
        {
            body.AddFirst(new Point(HeadPos));
            body.RemoveLast();
        }

        // Add a new element to the end of the body
        // Set its position based on the direction and last body part
        public void Grow()
        {
            Point tail = body.Last.Value;
            Point newTail = new Point(tail);
            newTail.ModByDirection(direction);
            body.AddLast(newTail);
        }
    }
}
