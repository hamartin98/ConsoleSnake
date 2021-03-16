using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    // Stores x and y direction modifiers, which can be used to calculate new position based on the direction
    class Direction
    {
        public int Xmod { get; } // x coordinate's modifier value, can be -1, 0 or 1 
        public int Ymod { get; } // y coordinate's modifier value, can be -1, 0 or 1

        public Direction(int x, int y)
        {
            this.Xmod = (x >= -1 && x <= 1) ? x : 0; // set the modifier to the given value, if it's incorrect set it to 0
            this.Ymod = (y >= -1 && y <= 1) ? y : 0; // set the modifier to the given value, if it's incorrect set it to 0
        }

        // Returns a direction based on the given character input
        // Returns null if the given character is invalid
        public static Direction getDirectionFromChar(char ch)
        {
            Direction dir = null;

            switch (ch)
            {
                case 'a':
                    dir = new Direction(-1, 0); // Left direction
                    break;
                case 'w':
                    dir = new Direction(0, -1); // Up direction
                    break;
                case 's':
                    dir = new Direction(0, 1); // Down direction
                    break;
                case 'd':
                    dir = new Direction(1, 0); // Right direction
                    break;
            }

            return dir;
        }
    }
}
