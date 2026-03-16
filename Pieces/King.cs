using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    internal class King : Piece
    {
        bool canCastle;
        bool isInCheck;

        public King(int x, int y, bool isWhite)
        {
            this.X = x;
            this.Y = y;

            this.isWhite = isWhite;

            canCastle = true;

            allPositions[x, y] = this;
            this.PieceType = "King";
        }

        public bool IsInCheck
        {
            get { return isInCheck; }
            set { isInCheck = value; }
        }

        public override bool[,] CheckMove()
        {
            Array.Clear(possibleMoves, 0, possibleMoves.Length);

            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = X + dx[i];
                int newY = Y + dy[i];

                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    if (allPositions[newX, newY] == null)
                    {
                        possibleMoves[newX, newY] = true;
                    }
                }
            }

            return possibleMoves;
        }

        public override bool[,] CheckTake()
        {
            Array.Clear(possibleTakes, 0, possibleTakes.Length);

            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newX = X + dx[i];
                int newY = Y + dy[i];

                if (newX >= 0 && newX < 8 && newY >= 0 && newY < 8)
                {
                    if (allPositions[newX, newY] != null &&
                        isWhite && 
                        !allPositions[newX, newY].isWhite)
                    {
                        possibleTakes[newX, newY] = true;
                    }
                    else if (allPositions[newX, newY] != null && 
                        !isWhite &&
                        allPositions[newX, newY].isWhite)
                    {
                        possibleTakes[newX, newY] = true;
                    }
                }
            }

            return possibleTakes;
        }
    }
}
