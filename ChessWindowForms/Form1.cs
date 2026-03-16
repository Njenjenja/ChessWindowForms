using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pieces;

namespace ChessWindowForms
{
    public partial class Form1 : Form
    {
        public Dictionary<Piece, PictureBox> piecePicture = new Dictionary<Piece, PictureBox>();

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(500, 550);
            boardPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            boardPicture.Size = new Size(480, 480);
            boardPicture.Image = Image.FromFile("Images/board.png");
            ShowBoard();
        }

        public void ShowBoard()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Piece.allPositions[x, y] != null &&
                        Piece.allPositions[x, y].isWhite)
                    {
                        PictureBox picture = new PictureBox();
                        piecePicture.Add(Piece.allPositions[x, y], picture);
                        picture.Image = Image.FromFile($"Images/Pieces/white{Piece.allPositions[x, y].PieceType}.png");
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Size = new Size(60, 60);
                        picture.Location = new Point(Piece.allPositions[x, y].X * 60, Piece.allPositions[x, y].Y * 60);
                        this.Controls.Add(picture);
                        picture.BringToFront();
                        if ((Piece.allPositions[x, y].X + Piece.allPositions[x, y].Y) % 2 == 0)
                        {
                            picture.BackColor = Color.White;
                        }
                        else
                        {
                            picture.BackColor = Color.FromArgb(39, 39, 39);
                        }
                        picture.Show();
                        Debug.WriteLine($"Image for {Piece.allPositions[x, y].isWhite} {Piece.allPositions[x, y].PieceType} on {Piece.allPositions[x, y].X}, {Piece.allPositions[x, y].Y}");
                    }
                
                    else if (Piece.allPositions[x, y] != null &&
                        !Piece.allPositions[x, y].isWhite)
                    {
                        PictureBox picture = new PictureBox();
                        piecePicture.Add(Piece.allPositions[x, y], picture);
                        picture.Image = Image.FromFile($"Images/Pieces/black{Piece.allPositions[x, y].PieceType}.png");
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Size = new Size(60, 60);
                        picture.Location = new Point(Piece.allPositions[x, y].X * 60, Piece.allPositions[x, y].Y * 60);
                        this.Controls.Add(picture);
                        picture.BringToFront();
                        if ((Piece.allPositions[x,y].X + Piece.allPositions[x, y].Y) % 2 == 0)
                        {
                            picture.BackColor = Color.White;
                        }
                        else
                        {
                            picture.BackColor = Color.FromArgb(39, 39, 39);
                        }
                        picture.Show();
                        Debug.WriteLine($"Image for {Piece.allPositions[x, y].isWhite} {Piece.allPositions[x, y].PieceType} on {Piece.allPositions[x, y].X}, {Piece.allPositions[x, y].Y}");
                    }
                }
            }
        }
    }
}
