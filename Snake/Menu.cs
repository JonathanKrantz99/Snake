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
        List<Player> scoreBoard = new List<Player>();

        public Menu()
        {
            this.scoreBoard = ReadFromFile();
        }

        public void MenuScreen()
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
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("4. Exit");

            ConsoleKey choice = Console.ReadKey(true).Key;
            MenuCoice(choice);
        }

        private void MenuCoice(ConsoleKey choice)
        {
            switch (choice)
            {
                case ConsoleKey.D1:
                    new Game(scoreBoard);
                    MenuScreen();
                    break;

                case ConsoleKey.D2:
                    ShowRules();
                    MenuScreen();
                    break;

                case ConsoleKey.D3:
                    PrintScoreBoard();
                    MenuScreen();
                    break;

                case ConsoleKey.D4:
                    break;
            }
        }

        private void ShowRules()
        {
            Console.Clear();
            Console.SetCursorPosition(34, 2);
            Console.WriteLine("Use 'W' 'A' 'S' 'D' to move");
            Console.SetCursorPosition(34, 3);
            Console.WriteLine("Eat food to grow your tail and earn points");
            Console.SetCursorPosition(34, 4);
            Console.WriteLine("Snake moves faster for each point you recieve");
            Console.SetCursorPosition(34, 5);
            Console.WriteLine("If you crash into the wall, you loose");
            Console.SetCursorPosition(34, 6);
            Console.WriteLine("If you crash into your own tail, you loose");
            Console.ReadKey();
        }

        private void PrintScoreBoard()
        {
            Console.Clear();
            for (int i = 0; i < scoreBoard.Count; i++)
            {
                Console.SetCursorPosition(40, i + 2);
                if (scoreBoard[i].ToString() == "<Empty>")
                {
                    Console.WriteLine("{0}. {1}", i + 1, scoreBoard[i]);
                }
                else
                {
                    Console.WriteLine("{0}. {1}: {2}", i + 1, scoreBoard[i].Name, scoreBoard[i].Score);
                }
            }
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }

        private List<Player> ReadFromFile()
        {
            List<Player> scoreBoard = new List<Player>();

            while (true)
            {
                try
                {
                    StreamReader reader = new StreamReader("HighScore.txt");
                    using (reader)
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            if (line == "<Empty>")
                            {
                                scoreBoard.Add(new Player());
                                line = reader.ReadLine();
                            }

                            else
                            {
                                string[] playerScores = line.Split(' ');
                                scoreBoard.Add(new Player(playerScores[0], Convert.ToInt32(playerScores[1])));
                                line = reader.ReadLine();
                            }
                        }
                    }
                    break;
                }

                catch (FileNotFoundException)
                {
                    StreamWriter sparaTillFil = new StreamWriter("HighScore.txt");
                    using (sparaTillFil)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            sparaTillFil.WriteLine(new Player());
                        }
                    }
                }
            }

            return scoreBoard;
        }
    }
}
