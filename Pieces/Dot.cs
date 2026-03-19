using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    public class Dot
    {
        int x;
        int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public readonly Piece piece;

        public static Dot[,] allDots;

        public Dot(int x, int y, Piece piece)
        {
            this.x = x;
            this.y = y;

            allDots[x, y] = this;
            this.piece = piece;
        }

    }
}
