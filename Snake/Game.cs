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
        private List<Player> scoreBoard = new List<Player>();
        private int highScore = 0;
        private int gameSpeed = 70;
        private bool gameOver = false;
        private bool goingUp = false;
        private bool goingDown = false;
        private bool goingLeft = false;
        private bool goingRight = false;
        public Game(List<Player> scoreBoard)
        {
            this.scoreBoard = scoreBoard;

            InitiateGame();
            StartGame();
        }
        public void StartGame()
        {
            ConsoleKey direction = Console.ReadKey(true).Key;
            while (gameOver == false)
            {
                Move(direction);

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
                    PlaceFood();
                    gameSpeed -= 1;
                }

                System.Threading.Thread.Sleep(gameSpeed);

                if (Console.KeyAvailable)
                {
                    ConsoleKey lastDirection = direction;
                    direction = Console.ReadKey(true).Key;

                    if (direction != ConsoleKey.W & direction != ConsoleKey.A & direction != ConsoleKey.S & direction != ConsoleKey.D)
                    {
                        direction = lastDirection;
                    }

                    if (IsOppositeDirection(direction, lastDirection))
                    {
                        direction = lastDirection;
                    }
                }
            }

            if (snake.Point * 10 > highScore)
            {
                Console.SetCursorPosition(86, 3);
                Console.WriteLine("New highscore!");
            }

            SaveToFile();

            if (PlayAgain())
            {
                Console.Clear();
                new Game(scoreBoard);
            }
        }

        private void Move(ConsoleKey keyInfo)
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
        }

        private bool CheckIfFoodIsEaten()
        {
            if (snake.X[0] == food.X & snake.Y[0] == food.Y)
            {
                snake.Point++;
                Console.SetCursorPosition(81, 1);
                Console.Write("Score: {0}", snake.Point * 10);
                return true;
            }
            return false;
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
            for (int i = 0; i < scoreBoard.Count; i++)
            {
                if (snake.Point * 10 > scoreBoard[i].Score)
                {
                    scoreBoard.RemoveAt(9);
                    Console.SetCursorPosition(81, 5);
                    Console.WriteLine("Enter name to save: ");
                    Console.SetCursorPosition(81, 6);
                    string name = Console.ReadLine();
                    scoreBoard.Insert(i, new Player(name, snake.Point * 10));
                    break;
                }
            }

            StreamWriter sparaTillFil = new StreamWriter("HighScore.txt");
            using (sparaTillFil)
            {
                for (int i = 0; i < scoreBoard.Count; i++)
                {
                    sparaTillFil.WriteLine(scoreBoard[i]);
                }
            }
        }

        private void InitiateGame()
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
            highScore = scoreBoard[0].Score;
            Console.SetCursorPosition(81, 0);
            Console.WriteLine("Highscore: {0}", highScore);
        }

        private bool PlayAgain()
        {
            Console.SetCursorPosition(81, 5);
            Console.WriteLine("Do you want to play again?");

            Console.SetCursorPosition(81, 6);
            Console.WriteLine("Press 1 for yes");

            Console.SetCursorPosition(81, 7);
            Console.WriteLine("Press 2 for no");

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

        private bool IsOppositeDirection(ConsoleKey newDirection, ConsoleKey lastDirection)
        {
            switch (newDirection)
            {
                case ConsoleKey.W:
                    if (lastDirection == ConsoleKey.S)
                    {
                        return true;
                    }
                    break;

                case ConsoleKey.A:
                    if (lastDirection == ConsoleKey.D)
                    {
                        return true;
                    }
                    break;

                case ConsoleKey.S:
                    if (lastDirection == ConsoleKey.W)
                    {
                        return true;
                    }
                    break;

                case ConsoleKey.D:
                    if (lastDirection == ConsoleKey.A)
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}
