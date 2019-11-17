using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food
    {
        private int x = 30;
        private int y = 15;

        public Food()
        {
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
