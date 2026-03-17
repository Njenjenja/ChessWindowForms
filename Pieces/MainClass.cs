using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pieces
{
    public class MainClass
    {
        static King whiteKing;
        static King blackKing;
        public static void Setup()
        {
            //Name the Kings (blackKing, whiteKing)

            for (int i = 0; i < 8; i++)
            {
                new Pawn(i, 1, false);
                new Pawn(i, 6, true);
            }

            new Rook(0, 0, false);
            new Rook(7, 0, false);

            new Rook(0, 7, true);
            new Rook(7, 7, true);


            new Knight(1, 0, false);
            new Knight(6, 0, false);

            new Knight(1, 7, true);
            new Knight(6, 7, true);


            new Bishop(2, 0, false);
            new Bishop(5, 0, false);

            new Bishop(2, 7, true);
            new Bishop(5, 7, true);


            blackKing = new King(3, 0, false);
            new Queen(4, 0, false);

            whiteKing = new King(3, 7, true);
            new Queen(4, 7, true);
        }

        



        public static void ShowPossibleMoves(Piece piece)
        {
            if (Dot.allDots is null) Dot.allDots = new Dot[8, 8];

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Dot.allDots[x, y] = null;

                    if (piece.possibleMoves[x, y] ||
                        piece.possibleTakes[x, y])
                    {
                        new Dot(x, y, piece);
                    }
                }
            }

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (piece.possibleMoves[x, y]) Debug.Write("1");
                    else if (piece.possibleTakes[x, y]) Debug.Write("2");
                    else Debug.Write("0");
                }
                Debug.WriteLine("");
            }
        }

        public static void MovePiece(Piece piece, int x, int y)
        {
            if (piece.possibleMoves[x, y] || piece.possibleTakes[x, y])
            {
                Piece.allPositions[x, y] = Piece.allPositions[piece.X, piece.Y];
                Piece.allPositions[piece.X, piece.Y] = null;

                piece.X = x; 
                piece.Y = y;
            }
            else
            {
                Debug.WriteLine("Invalid move");
            }
        }

        public static void UpdateInfo()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Piece.allPositions[x, y] != null)
                    {
                        Piece.allPositions[x, y].CheckMove();
                        Piece.allPositions[x, y].CheckTake();
                    } 
                }
            }

            //Checking Check
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Piece.allPositions[x, y] != null)
                    {
                        CheckIfInCheck(Piece.allPositions[x, y]);
                        CheckIfMoveResultsInCheck(Piece.allPositions[x, y]);
                    }
                }
            }
        }

        public static void CheckIfInCheck(Piece piece)
        {
            if (piece.isWhite &&
                piece.possibleTakes[blackKing.X, blackKing.Y])
            {
                blackKing.IsInCheck = true;
                Debug.WriteLine("Black in check");
            }
            else if(!piece.isWhite &&
                piece.possibleTakes[whiteKing.X, whiteKing.Y])
            {
                whiteKing.IsInCheck = true;
                Debug.WriteLine("White in check");
            }
        }

        //create a method that gets every King possible move and take
        //and check if that move will result in a check
        public static void CheckIfMoveResultsInCheck(Piece piece)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if(piece.isWhite &&
                       piece.possibleMoves[x, y] &&
                       blackKing.possibleMoves[x, y])
                    {
                        blackKing.possibleMoves[x, y] = false;
                    }
                    else if (!piece.isWhite &&
                       piece.possibleMoves[x, y] &&
                       whiteKing.possibleMoves[x, y])
                    {
                        whiteKing.possibleMoves[x, y] = false;
                    }
                }
            }
        }
    }
}
