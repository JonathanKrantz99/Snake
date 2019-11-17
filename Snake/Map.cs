using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Map
    {
        public Map()
        {
        }

        public void PaintMap()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < 78; i++)
            {
                Console.Write("#");
            }
            Console.SetCursorPosition(1, 27);
            for (int i = 0; i < 78; i++)
            {
                Console.Write("#");
            }

            for (int i = 0; i < 27; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("#");
            }

            for (int i = 0; i < 28; i++)
            {
                Console.SetCursorPosition(78, i);
                Console.Write("#");
            }
        }

        public bool IsWallHit(int x, int y)
        {
            if (x == 1 || x == 78 || y == 0 || y == 27)
            {
                return true;
            }

            else return false;
        }
    }
}
