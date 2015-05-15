using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatapultGame.Screens
{
    class Ground
    {
        Rectangle rect;
        Texture2D texture;
        int pass;

        public Ground(Rectangle rect, Texture2D texture, int pass)
        {
            this.rect = rect;
            this.texture = texture;
            this.pass = pass;
        }
    }
}
