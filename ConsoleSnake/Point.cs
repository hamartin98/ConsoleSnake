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
    }
}
