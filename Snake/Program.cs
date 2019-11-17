using System;
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

            Menu menu = new Menu();
            menu.MenuScreen();
        }
    }
}
