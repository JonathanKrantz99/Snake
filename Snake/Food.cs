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
        private bool isEaten = false;
        private Random random = new Random();

        public Food()
        {
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

        public bool IsEaten
        {
            get { return this.isEaten; }
            set { this.isEaten = value; }
        }

        public string SnakeFood
        {
            get { return this.snakeFood; }
        }

        public override string ToString()
        {
            this.X = random.Next(1, 77);
            this.Y = random.Next(1, 26);

            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            return this.SnakeFood;
        }
        
        
    }
}
