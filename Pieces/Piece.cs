using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    interface Ipiece
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public abstract class Piece : Ipiece
    {
        int x;
        int y;

        public readonly bool isWhite;

        string pieceType;

        /*for each possible move
         *check if true  
         *if true create a object from Dot
         *link dot image with dictionaries
         */
        public bool[,] possibleMoves = new bool[8, 8];
        public bool[,] possibleTakes = new bool[8, 8];

        public bool this[int x, int y]
        {
            get
            {
                return possibleMoves[x, y];
            }
            set
            {
                possibleMoves[x, y] = value;
            }
        }

        public static Piece[,] allPositions = new Piece[8,8];

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

        public string PieceType 
        { 
            get { return pieceType; } 
            set { pieceType = value; }
        }

        ~Piece()
        {
            Debug.WriteLine($"Deleted {X}, {Y}");
        }

        public virtual bool[,] CheckMove()
        {
            return null;
        }

        public virtual bool[,] CheckTake()
        {
            return null;
        }
    }
}
