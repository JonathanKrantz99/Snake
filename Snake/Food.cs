using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private int x;
        private int y;
        private string snakeFood = "o";
        public Food(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public string SnakeFood
        {
            get { return this.snakeFood; }
        }

    }
}
