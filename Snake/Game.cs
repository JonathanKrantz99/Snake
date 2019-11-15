using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Game
    {
        public Snake snake = new Snake();
        private Food food = new Food();
        private Map map = new Map();
        private bool gameOver = false;
        private bool goingUp = false;
        private bool goingDown = false;
        private bool goingLeft = false;
        private bool goingRight = false;
        public Game()
        {
            // paint the boundry
            map.PaintMap();

            // Paint the snake head
            Console.SetCursorPosition(snake.X[0], snake.Y[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");

            // Paint the food
            Console.WriteLine(food);
        }

        public void StartGame()
        {
            ConsoleKey keyInfo = Console.ReadKey().Key;
            while (gameOver == false)
            {
                Move(keyInfo);

                snake.Paint();

                if (map.IsWallHit(snake.X[0], snake.Y[0]))
                {
                    gameOver = true;
                }

                if (CheckIfFoodIsEaten())
                {
                    food.IsEaten = true;
                }

                if (food.IsEaten)
                {
                    Console.WriteLine(food);
                    food.IsEaten = false;
                }

                System.Threading.Thread.Sleep(70);

                if (Console.KeyAvailable) keyInfo = Console.ReadKey().Key;
            }
        }

        public bool CheckIfFoodIsEaten()
        {
            if (snake.X[0] == food.X & snake.Y[0] == food.Y)
            {
                snake.Point++;
                return true;
            }

            return false;
        }

        private void Move(ConsoleKey keyInfo)
        {
            switch (keyInfo)
            {
                case ConsoleKey.W:
                    if (goingDown)
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]++;
                    }

                    else
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]--;

                        goingUp = true;
                        goingDown = false;
                        goingLeft = false;
                        goingRight = false;
                    }
                    break;

                case ConsoleKey.S:
                    if (goingUp)
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]--;
                    }

                    else
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.Y[0]++;

                        goingDown = true;
                        goingUp = false;
                        goingLeft = false;
                        goingRight = false;
                    }
                    break;

                case ConsoleKey.A:
                    if (goingRight)
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]++;
                    }

                    else
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]--;

                        goingLeft = true;
                        goingUp = false;
                        goingDown = false;
                        goingRight = false;
                    }
                    break;

                case ConsoleKey.D:
                    if (goingLeft)
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]--;
                    }

                    else
                    {
                        Console.SetCursorPosition(snake.X[0], snake.Y[0]);
                        Console.Write(" ");
                        snake.X[0]++;

                        goingRight = true;
                        goingUp = false;
                        goingDown = false;
                        goingLeft = false;
                    }
                    break;
            }
        }
    }
}
