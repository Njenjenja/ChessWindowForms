using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    internal class Dot
    {
        public int x;
        public int y;

        public static Dot[,] allDots;

        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;

            allDots[x, y] = this;
        }

    }
}
