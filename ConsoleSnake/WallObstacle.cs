using System;

namespace ConsoleSnake
{
    class WallObstacle : Obstacle
    {
        public WallObstacle(Point position) : base(position)
        {
            this.img = new Image('#', ConsoleColor.Blue);
            this.isDestroyable = false;
        }
    }
}
