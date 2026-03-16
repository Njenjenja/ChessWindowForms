using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int x, int y, bool isWhite)
        {
            this.X = x;
            this.Y = y;

            this.isWhite = isWhite;

            allPositions[x, y] = this;
            this.PieceType = "Bishop";
        }

        public override bool[,] CheckMove()
        {
            Array.Clear(possibleMoves, 0, possibleMoves.Length);

            for (int i = X + 1, j = Y + 1; i <= 7 && j <= 7; i++, j++)
            {
                if (allPositions[i, j] is null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }
            for (int i = X - 1, j = Y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (allPositions[i, j] is null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }
            for (int i = X + 1, j = Y - 1; i <= 7 && j >= 0; i++, j--)
            {
                if (allPositions[i, j] is null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }
            for (int i = X - 1, j = Y + 1; i >= 0 && j <= 7; i--, j++)
            {
                if (allPositions[i, j] is null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }


            return possibleMoves;
        }

        public override bool[,] CheckTake()
        {
            Array.Clear(possibleTakes, 0, possibleTakes.Length);

            if (isWhite)
            {
                for (int i = X + 1, j = Y + 1; i <= 7 && j <= 7; i++, j++)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X - 1, j = Y - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X + 1, j = Y - 1; i <= 7 && j >= 0; i++, j--)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X - 1, j = Y + 1; i >= 0 && j <= 7; i--, j++)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
            }

            else
            {
                for (int i = X + 1, j = Y + 1; i <= 7 && j <= 7; i++, j++)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X - 1, j = Y - 1; i >= 0 && j >= 0; i--, j--)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X + 1, j = Y - 1; i <= 7 && j >= 0; i++, j--)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X - 1, j = Y + 1; i >= 0 && j <= 7; i--, j++)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleTakes[i, j] = true;
                        break;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
            }


            return possibleTakes;
        }
    }
}
