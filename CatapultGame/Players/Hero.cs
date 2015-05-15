using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatapultGame.Players
{
    class Hero
    {

        public List<Squad> army = new List<Squad>();
        Point currentPosition;

        public Hero(int x, int y)
        {
            currentPosition.X = x;
            currentPosition.Y = y;
        }

        public Hero() : this(0,0) { } 
    }
}
