using System.Collections.Generic;
using System.Text;

namespace ConsoleSnake
{
    // Represent an obstacle on the map
    abstract class Obstacle
    {
        protected bool isDestroyable;
        protected Point position;
        protected Image img;
        protected int score = 0;

        public bool IsDestroyable { get => isDestroyable; }
        public Point Position { get => position; }
        public Image Img { get => img; }
        public int Score { get => score; }

        protected Obstacle(Point position)
        {
            this.position = position;
        }
    }
}
