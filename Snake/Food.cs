using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private int x = 30;
        private int y = 15;
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

        public void PlaceFood(int[] snakeX, int[] snakeY)
        {
            int testResult = 0;
            X = random.Next(2, 77);
            Y = random.Next(2, 26);

            while (true)
            {
                for (int i = 0; i < snakeX.Length; i++)
                {
                    if (X == snakeX[i] & Y == snakeY[i])
                    {
                        X = random.Next(2, 77);
                        Y = random.Next(2, 26);
                    }
                    else testResult++;
                }

                if (testResult == snakeX.Length) break;
            }

            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("o");
        }

        public bool IsEaten(int snakeXPos, int snakeYPos)
        {
            if (snakeXPos == X & snakeYPos == Y)
            {
                return true;
            }
            return false;
        }
    }
}
