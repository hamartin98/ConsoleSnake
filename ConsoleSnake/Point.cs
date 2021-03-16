using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    // Represent a point on the map with x and y coordinates
    class Point
    {
        public int X { get; set; } // the x coordinate of the point
        public int Y { get; set; } // the y coordinate of the point

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        // Sets the x and y coordinates of the point to the given parameters
        public void SetPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // Sets the x and y coordinates of the point to the coordinates of the given point
        public void SetPosition(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        // Modifes the position based on the given direction
        public void ModByDirection(Direction direction)
        {
            this.X += direction.Xmod;
            this.Y += direction.Ymod;
        }

        // Returns a new Point object with random x and y coordinates between 1 and the given maximum values
        public static Point GetRandom(int xMax, int yMax)
        {
            Random rand = new Random();
            int x = rand.Next(1, xMax);
            int y = rand.Next(1, yMax);
            return new Point(x, y);
        }

        // Check equality between two point object
        // Return true if they are equal
        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.X == p2.X && p1.Y == p2.Y);
        }

        // Check equality between two point object
        // Return true if they are not equal
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1.X == p2.X && p1.Y == p2.Y);
        }

        public override bool Equals(object obj)
        {
            Point pos = obj as Point;
            return X == pos.X && Y == pos.Y;
        }
    }
}
