using System;

namespace ConsoleSnake
{
    // Stores an image and a color to represent an item, that can be displayed on the console
    class Image
    {
        private char Img { get; } // the character to be displayed on the console
        public ConsoleColor Color { get; } // the displayed character's color

        public Image(char img, ConsoleColor color)
        {
            this.Img = img;
            this.Color = color;
        }

        // Display the image at the given position on the console
        public void PrintToScreen(Point position)
        {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = Color;
            Console.Write(Img);
        }
    }
}
