using System;

namespace ConsoleSnake
{
    class Food : Obstacle
    {
        public Food(Point position) : base(position)
        {
            this.img = new Image('¤', ConsoleColor.Red);
            this.isDestroyable = true;
            this.score = 10;
        }
    }
}
