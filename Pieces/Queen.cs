using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    public class Queen : Piece
    {
        public Queen(int x, int y, bool isWhite)
        {
            this.X = x;
            this.Y = y;

            this.isWhite = isWhite;

            allPositions[x, y] = this;
            this.PieceType = "Queen";
        }

        public override bool[,] CheckMove()
        {
            Array.Clear(possibleMoves, 0, possibleMoves.Length);

            for (int i = X, j = Y; i <= 7 && j <= 7; i++, j++)
            {
                if (allPositions[i, j] == null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }
            for (int i = X, j = Y; i >= 0 && j >= 0; i--, j--)
            {
                if (allPositions[i, j] == null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }

            for (int i = X, j = Y; i <= 7 && j >= 0; i++, j--)
            {
                if (allPositions[i, j] == null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }
            for (int i = X, j = Y; i >= 0 && j <= 7; i--, j++)
            {
                if (allPositions[i, j] == null)
                {
                    possibleMoves[i, j] = true;
                }
                else break;
            }



            for (int i = X; i <= 7; i++)
            {
                if (allPositions[i, Y] == null)
                {
                    possibleMoves[i, Y] = true;
                }
                else break;
            }
            for (int i = X; i >= 0; i--)
            {
                if (allPositions[i, Y] == null)
                {
                    possibleMoves[i, Y] = true;
                }
                else break;
            }

            for (int i = Y; i <= 7; i++)
            {
                if (allPositions[X, i] == null)
                {
                    possibleMoves[X, i] = true;
                }
                else break;
            }
            for (int i = Y; i >= 0; i--)
            {
                if (allPositions[X, i] == null)
                {
                    possibleMoves[X, i] = true;
                }
                else break;
            }

            return possibleMoves;
        }

        public override bool[,] CheckTake()
        {
            Array.Clear(possibleMoves, 0, possibleMoves.Length);

            if (isWhite)
            {
                for (int i = X; i <= 7; i++)
                {
                    if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                    }
                    else if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite) break;
                }
                for (int i = X; i >= 0; i--)
                {
                    if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                    }
                    else if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite) break;
                }

                for (int i = Y; i <= 7; i++)
                {
                    if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                    }
                    else if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite) break;
                }
                for (int i = Y; i >= 0; i--)
                {
                    if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                    }
                    else if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite) break;
                }




                for (int i = X, j = Y; i <= 7 && j <= 7; i++, j++)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i >= 0 && j >= 0; i--, j--)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i <= 7 && j >= 0; i++, j--)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i >= 0 && j <= 7; i--, j++)
                {
                    if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite) break;
                }
            }


            else
            {
                for (int i = X; i <= 7; i++)
                {
                    if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                    }
                    else if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite) break;
                }
                for (int i = X; i >= 0; i--)
                {
                    if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                    }
                    else if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite) break;
                }

                for (int i = Y; i <= 7; i++)
                {
                    if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                    }
                    else if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite) break;
                }
                for (int i = Y; i >= 0; i--)
                {
                    if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                    }
                    else if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite) break;
                }


                for (int i = X, j = Y; i <= 7 && j <= 7; i++, j++)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i >= 0 && j >= 0; i--, j--)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i <= 7 && j >= 0; i++, j--)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
                for (int i = X, j = Y; i >= 0 && j <= 7; i--, j++)
                {
                    if (allPositions[i, j] != null &&
                        !allPositions[i, j].isWhite)
                    {
                        possibleMoves[i, j] = true;
                    }
                    else if (allPositions[i, j] != null &&
                        allPositions[i, j].isWhite) break;
                }
            }


            return possibleMoves;
        }
    }
}