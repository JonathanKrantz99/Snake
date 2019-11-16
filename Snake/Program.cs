﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(109, 28);
            Console.CursorVisible = false;
            new Game();

            while (true)
            {
                if (PlayAgain())
                {
                    Console.Clear();
                    new Game();
                }

                else break;
            }
        }

        private static bool PlayAgain()
        {
            Console.SetCursorPosition(81, 5);
            Console.WriteLine("Do you want to play again?");

            Console.SetCursorPosition(81, 6);
            Console.WriteLine("1. Yes");

            Console.SetCursorPosition(81, 7);
            Console.WriteLine("2. No");

            ConsoleKey answer = Console.ReadKey(true).Key;

            while (true)
            {
                if (answer == ConsoleKey.D1)
                {
                    return true;
                }

                else if (answer == ConsoleKey.D2)
                {
                    return false;
                }

                else
                {
                    Console.SetCursorPosition(81, 5);
                    Console.WriteLine("Do you want to play again?");

                    Console.SetCursorPosition(81, 6);
                    Console.WriteLine("1. Yes");

                    Console.SetCursorPosition(81, 7);
                    Console.WriteLine("2. No");

                    answer = Console.ReadKey(true).Key;
                }
            }
        }
    }
}
