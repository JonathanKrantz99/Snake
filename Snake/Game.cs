using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Game
    {
        public Snake snake = new Snake();
        private Food food = new Food();
        private Map map = new Map();
        private Random random = new Random();
        private int highScore = 0;
        private int gameSpeed = 70;
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
            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("o");

            // Print the score
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(81, 1);
            Console.WriteLine("Score: {0}", snake.Point * 10);

            // Print highscore
            ReadFromFile();
            Console.SetCursorPosition(81, 0);
            Console.WriteLine("Highscore: {0}", highScore);

            StartGame();
        }
        public void StartGame()
        {
            ConsoleKey keyInfo = Console.ReadKey(true).Key;
            while (gameOver == false)
            {
                Move(keyInfo);

                if (snake.CheckSelfCollision())
                {
                    gameOver = true;
                }

                snake.Paint();

                if (map.IsWallHit(snake.X[0], snake.Y[0]))
                {
                    gameOver = true;
                }

                if (CheckIfFoodIsEaten())
                {
                    food.IsEaten = true;
                    gameSpeed -= 1;
                }

                if (food.IsEaten)
                {
                    PlaceFood();
                    food.IsEaten = false;
                }

                System.Threading.Thread.Sleep(gameSpeed);

                if (Console.KeyAvailable) keyInfo = Console.ReadKey(true).Key;
            }

            if(snake.Point*10 > highScore)
            {
                Console.SetCursorPosition(86, 3);
                Console.WriteLine("New highscore!");
            }

            SaveToFile();
        }

        public bool CheckIfFoodIsEaten()
        {
            if (snake.X[0] == food.X & snake.Y[0] == food.Y)
            {
                snake.Point++;
                Console.SetCursorPosition(81, 1);
                Console.Write("Score: {0}", snake.Point*10);
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

        private void PlaceFood()
        {
            int testResult = 0;
            food.X = random.Next(2, 77);
            food.Y = random.Next(2, 26);

            while (true)
            {
                for (int i = 0; i < snake.X.Length; i++)
                {
                    if (food.X == snake.X[i] & food.Y == snake.Y[i])
                    {
                        food.X = random.Next(2, 77);
                        food.Y = random.Next(2, 26);
                    }
                    else testResult++;
                }

                if (testResult == snake.X.Length) break;
            }

            Console.SetCursorPosition(food.X, food.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("o");
        }

        private void SaveToFile()
        {
            if(snake.Point*10 > highScore)
            {
                StreamWriter sparaTillFil = new StreamWriter("HighScore.txt");
                using (sparaTillFil)
                {
                    sparaTillFil.WriteLine(snake.Point * 10);
                }
            }
        }

        private void ReadFromFile()
        {
            try
            {
                StreamReader reader = new StreamReader("HighScore.txt");
                using (reader)
                {
                    string line = reader.ReadLine();
                    highScore = Convert.ToInt32(line);
                }
            }
            
            catch (FileNotFoundException)
            {
                StreamWriter sparaTillFil = new StreamWriter("HighScore.txt");
                using (sparaTillFil)
                {
                    sparaTillFil.WriteLine(snake.Point * 10);
                }
            }
        }
    }
}
