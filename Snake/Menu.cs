using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Menu
    {
        private int[] scoreBoard;

        public Menu()
        {
            MenuScreen();
        }

        private void MenuScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Welcome to the snake game!");
            Console.SetCursorPosition(40, 3);
            Console.WriteLine("1. Play");
            Console.SetCursorPosition(40, 4);
            Console.WriteLine("2. Show rules");
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("3. View scoreboard");

            ConsoleKey choice = Console.ReadKey(true).Key;
            MenuCoice(choice);
        }

        private void MenuCoice(ConsoleKey choice)
        {
            while (true)
            {
                switch (choice)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        new Game();
                        break;

                    case ConsoleKey.D2:
                        break;

                    case ConsoleKey.D3:
                        break;
                }
                if (Program.PlayAgain())
                {

                }
                else break;
            }

            MenuScreen();
        }

        


    }
}
