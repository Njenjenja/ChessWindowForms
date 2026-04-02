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
        public Dictionary<Dot, PictureBox> dotPicture = new Dictionary<Dot, PictureBox>();

        public bool whiteTurn;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(500, 550);
            boardPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            boardPicture.Size = new Size(480, 480);
            boardPicture.Image = Image.FromFile("Images/board.png");
            whiteTurn = true;
            ShowBoard();
        }

        
        ///<summary>
        ///Prikaze vse figure in pike na sahovnici
        ///</summary>
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
                        picture.Click += ClickPiece;
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
                        picture.Click += ClickPiece;
                        Debug.WriteLine($"Image for {Piece.allPositions[x, y].isWhite} {Piece.allPositions[x, y].PieceType} on {Piece.allPositions[x, y].X}, {Piece.allPositions[x, y].Y}");
                    }
                }
            }
        }

        ///<summary>
        ///Postavi piko logicno
        ///</summary>
        public void PlaceDot()
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (Dot.allDots[x,y] != null)
                    {
                        PictureBox picture = new PictureBox();
                        dotPicture.Add(Dot.allDots[x, y], picture);
                        picture.Image = Image.FromFile($"Images/dot.png");
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Size = new Size(60, 60);
                        picture.Location = new Point(Dot.allDots[x, y].X * 60, Dot.allDots[x, y].Y * 60);
                        this.Controls.Add(picture);
                        picture.BringToFront();
                        if ((Dot.allDots[x, y].X + Dot.allDots[x, y].Y) % 2 == 0)
                        {
                            picture.BackColor = Color.White;
                        }
                        else
                        {
                            picture.BackColor = Color.FromArgb(39, 39, 39);
                        }
                        picture.Show();
                        picture.Click += ClickDot;
                        Debug.WriteLine($"Image for Dot on {Dot.allDots[x, y].X}, {Dot.allDots[x, y].Y}");
                    }
                }
            }
        }

        ///<summary>
        ///Po pomoti sem kliknil na Form1 in se mi ne da ukvarjati z konstruktorjem
        ///</summary>
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        ///<summary>
        ///Aktivira se ko kliknemo figuro ->
        ///Postavi pike
        ///</summary>
        private void ClickPiece(object sender, EventArgs e)
        {
            PictureBox clickedPicture = sender as PictureBox;

            Piece clickedPiece = piecePicture.FirstOrDefault(kvp => kvp.Value == clickedPicture).Key;

            if (clickedPiece.isWhite && whiteTurn || (!clickedPiece.isWhite && !whiteTurn))
            {
                if (clickedPiece != null)
                {
                    Debug.WriteLine($"Clicked piece {clickedPiece.PieceType} at ({clickedPiece.X}, {clickedPiece.Y})");
                }
                else
                {
                    Debug.WriteLine($"The piece doesn't exist");
                }

                clickedPiece.CheckTake();
                clickedPiece.CheckMove();

                DeleteDots();
                MainClass.ShowPossibleMoves(clickedPiece);

                PlaceDot();
            }
            else MessageBox.Show("Not your turn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        ///<summary>
        ///Aktivira se ko kliknemo piko ->
        ///Premakne figuro
        ///</summary>
        private void ClickDot(object sender, EventArgs e)
        {
            PictureBox clickedPicture = sender as PictureBox;

            Dot clickedDot = dotPicture.FirstOrDefault(kvp => kvp.Value == clickedPicture).Key;

            DeleteDots();
            DeletePieces();
            MainClass.MovePiece(clickedDot.piece, clickedDot.X, clickedDot.Y);

            ShowBoard();
            whiteTurn = !whiteTurn;
        }

        ///<summary>
        ///Zbrise vse pike
        ///</summary>
        public void DeleteDots()
        {
            foreach(var kvp in dotPicture)
            {
                PictureBox picture = kvp.Value;

                Controls.Remove(picture);
                picture.Dispose();
            }

            dotPicture.Clear();
        }

        ///<summary>
        ///Zbrise vse figure
        ///</summary>
        public void DeletePieces()
        {
            foreach (var kvp in piecePicture)
            {
                PictureBox picture = kvp.Value;

                Controls.Remove(picture);
                picture.Dispose();
            }

            piecePicture.Clear();
        }
    }
}
