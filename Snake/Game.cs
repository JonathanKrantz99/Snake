﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        //(keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape
        private Snake snake = new Snake();
        private bool gameOver = false;
        private bool foodIsEaten = false;
        private Food food = new Food(15, 15);

        public Game()
        {
            // Print the boundry
            Boundry();

            // Paint the snake head
            Console.SetCursorPosition(snake.X[0], snake.Y[0]);
            Console.ForegroundColor = snake.SnakeColor;
            Console.WriteLine((char)2);

            // Paint the food
            Console.WriteLine(food);
        }

        public void StartGame()
        {
            ConsoleKey keyInfo = Console.ReadKey().Key;
            while (gameOver == false)
            {
                switch (keyInfo)
                {
                    case ConsoleKey.W:
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]--;
                        break;

                    case ConsoleKey.S:
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]++;
                        break;

                    case ConsoleKey.A:
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]--;
                        break;

                    case ConsoleKey.D:
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]++;
                        break;
                }

                snake.Paint();

                if (IsWallHit(snake.X[0], snake.Y[0])) gameOver = true;

                if (CheckIfFoodIsEaten()) foodIsEaten = true;

                if (foodIsEaten)
                {
                    Console.WriteLine(food);
                    foodIsEaten = false;
                }

                System.Threading.Thread.Sleep(50);

                if (Console.KeyAvailable) keyInfo = Console.ReadKey().Key;
            }
        }

        

        private void Boundry()
        {
            for(int i = 0; i < 78; i++)
            {
                Console.Write("#");
            }
            Console.SetCursorPosition(0, 27);
            for (int i = 0; i < 78; i++)
            {
                Console.Write("#");
            }
            
            for (int i = 0; i < 27; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
            }

            for (int i = 0; i < 28; i++)
            {
                Console.SetCursorPosition(78, i);
                Console.Write("#");
            }
        }

        private bool IsWallHit(int x, int y)
        {
            if (x == 0 || x == 78 || y == 0 || y == 27)
            {
                return true;
            }

            else return false;
        }

        private bool CheckIfFoodIsEaten()
        {
            if(snake.X[0] == food.X & snake.Y[0] == food.Y)
            {
                snake.Point++;
                return true;
            }

            return false;
        }
    }
}
