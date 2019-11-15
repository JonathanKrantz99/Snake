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
        private ConsoleColor snakeColor = ConsoleColor.Yellow;

        public Snake()
        {
            this.X[0] = 50;
            this.Y[0] = 15;
        }

        //public int SnakeLenght
        //{
        //    set { this.snakeLenght = value; }

        //    get { return this.snakeLenght; }
        //}

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

        public ConsoleColor SnakeColor
        {
            get { return this.snakeColor; }
        }

    }
}
