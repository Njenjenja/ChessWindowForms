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



            for (int i = X + 1; i <= 7; i++)
            {
                if (allPositions[i, Y] is null)
                {
                    possibleMoves[i, Y] = true;
                }
                else break;
            }
            for (int i = X - 1; i >= 0; i--)
            {
                if (allPositions[i, Y] is null)
                {
                    possibleMoves[i, Y] = true;
                }
                else break;
            }

            for (int i = Y + 1; i <= 7; i++)
            {
                if (allPositions[X, i] is null)
                {
                    possibleMoves[X, i] = true;
                }
                else break;
            }
            for (int i = Y - 1; i >= 0; i--)
            {
                if (allPositions[X, i] is null)
                {
                    possibleMoves[X, i] = true;
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




                for (int i = X + 1; i <= 7; i++)
                {
                    if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                        break;
                    }
                    else if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite) break;
                }
                for (int i = X - 1; i >= 0; i--)
                {
                    if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                        break;
                    }
                    else if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite) break;
                }

                for (int i = Y + 1; i <= 7; i++)
                {
                    if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                        break;
                    }
                    else if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite) break;
                }
                for (int i = Y - 1; i >= 0; i--)
                {
                    if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                        break;
                    }
                    else if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite) break;
                }
            }

            ////////////////////////////////////////////////
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





                for (int i = X + 1; i <= 7; i++)
                {
                    if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                        break;
                    }
                    else if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite) break;
                }
                for (int i = X - 1; i >= 0; i--)
                {
                    if (allPositions[i, Y] != null &&
                        allPositions[i, Y].isWhite)
                    {
                        possibleTakes[i, Y] = true;
                        break;
                    }
                    else if (allPositions[i, Y] != null &&
                        !allPositions[i, Y].isWhite) break;
                }

                for (int i = Y + 1; i <= 7; i++)
                {
                    if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                        break;
                    }
                    else if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite) break;
                }
                for (int i = Y - 1; i >= 0; i--)
                {
                    if (allPositions[X, i] != null &&
                        allPositions[X, i].isWhite)
                    {
                        possibleTakes[X, i] = true;
                        break;
                    }
                    else if (allPositions[X, i] != null &&
                        !allPositions[X, i].isWhite) break;
                }
            }


            return possibleTakes;
        }
    }
}