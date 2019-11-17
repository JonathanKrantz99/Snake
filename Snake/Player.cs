using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Player
    {
        private string name;
        private int score;

        public Player(string name = null, int score = 0)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        public override string ToString()
        {
            if(Name is null & Score == 0)
            {
                return string.Format("<Empty>");
            }

            else
            {
                return string.Format("{0} {1}", Name, Score);
            }
        }
    }
}
