using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    public class Pawn : Piece
    {
        public Pawn(int x, int y, bool isWhite)
        {
            this.X = x;
            this.Y = y;

            this.isWhite = isWhite;

            allPositions[x, y] = this;
            this.PieceType = "Pawn";
        }

        public override bool[,] CheckMove()
        {
            Array.Clear(possibleMoves, 0, possibleMoves.Length);


            if (isWhite)
            {
                if (Y == 6)
                {
                    int newY = Y - 1;
                    int newYTwo = Y - 2;

                    if (newY > 0 && allPositions[X, newY] is null)
                    {
                        possibleMoves[X, newY] = true;

                        if (newYTwo > 0 && allPositions[X, newYTwo] is null)
                        {
                            possibleMoves[X, newYTwo] = true;
                        }
                    }
                }
                else
                {
                    int newY = Y - 1;

                    if (newY > 0 && allPositions[X, newY] is null)
                    {
                        possibleMoves[X, newY] = true;
                    }
                }
            }

            if (!isWhite)
            {
                if (Y == 1)
                {
                    int newY = Y + 1;
                    int newYTwo = Y + 2;

                    if (newY > 0 && allPositions[X, newY] is null)
                    {
                        possibleMoves[X, newY] = true;

                        if (newYTwo > 0 && allPositions[X, newYTwo] is null)
                        {
                            possibleMoves[X, newYTwo] = true;
                        }
                    }
                }
                else
                {
                    int newY = Y + 1;

                    if (newY > 0 && allPositions[X, newY] is null)
                    {
                        possibleMoves[X, newY] = true;
                    }
                }

            }


            return possibleMoves;
        }

        public override bool[,] CheckTake()
        {
            Array.Clear(possibleTakes, 0, possibleTakes.Length);


            if(isWhite)
            {
                int newY = Y - 1;


                if (newY > 0 && X > 0 &&
                    allPositions[X - 1, newY] != null &&
                    allPositions[X - 1, newY].isWhite == false)
                {
                    possibleTakes[X - 1, newY] = true;
                }
                if (newY < 7 && X < 7 &&
                    allPositions[X + 1, newY] != null &&
                    allPositions[X + 1, newY].isWhite == false)
                {
                    possibleTakes[X + 1, newY] = true;
                }
            }
            else
            {
                int newY = Y + 1;


                if (newY > 0 && X > 0 &&
                    allPositions[X - 1, newY] != null &&
                    allPositions[X - 1, newY].isWhite == true)
                {
                    possibleTakes[X - 1, newY] = true;
                }
                if (newY < 7 && X < 7 &&
                    allPositions[X + 1, newY] != null &&
                    allPositions[X + 1, newY].isWhite == true)
                {
                    possibleTakes[X + 1, newY] = true;
                }
            }


            return possibleTakes;
        }
    }
}
