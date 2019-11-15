using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        private int[] x = new int[50];
        private int[] y = new int[50];
        private int point;

        public Snake()
        {
            this.X[0] = 50;
            this.Y[0] = 15;
        }

        public int[] X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int[] Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int Point
        {
            get { return this.point; }
            set { this.point = value; }
        }

        public void Paint()
        {
            // Head
            Console.SetCursorPosition(X[0], Y[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");

            // Body
            for (int i = 1; i < point + 1; i++)
            {
                Console.SetCursorPosition(X[i], Y[i]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }

            // Erase last body part
            Console.SetCursorPosition(X[point + 1], Y[point + 1]);
            Console.WriteLine(" ");

            // Update snake array
            for (int i = point + 1; i > 0; i--)
            {
                X[i] = X[i - 1];
                Y[i] = Y[i - 1];
            }
        }
    }
}
