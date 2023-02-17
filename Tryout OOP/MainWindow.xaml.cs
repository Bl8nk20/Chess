using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tryout_OOP;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    TextBlock[,] textBlocks = new TextBlock[8, 8];
    Pieces[] pieces = new Pieces[32];
    Pieces movedPiece;

    public MainWindow()
    {
        InitializeComponent();
        pieces = InitialPieces();
        DrawBoard();
    }

    /// <summary>
    /// 
    /// </summary>
    private void DrawBoard()
    {
        // load the board to the gui
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                TextBlock b = new TextBlock();
                // draw the chessboard
                b.Width = 72.5;
                b.Height = 72.5;
                b.FontSize = 45;
                b.Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                spielfeld.Children.Add(b);
                textBlocks[i, j] = b;
                Canvas.SetLeft(b, 72.5 * i);
                Canvas.SetBottom(b, 72.5 * j);
                b.MouseDown += MouseClicked;
                b.MouseUp += MouseReleased;
                //b.MouseEnter += MouseEntered;
                b.MouseLeave += MouseLeaved;

            }
        }

        //pieces[0].MoveTo(new PointStruct(0, 4));
        //
        DrawPieces();
    }

    /// <summary>
    /// 
    /// </summary>
    void DrawPieces()
    {
        // Draw the ChessPieces
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                //
                textBlocks[i, j].Text = "";
                //
                for (byte k = 0; k < pieces.Length; k++)
                {
                    //
                    if (pieces[k].Position.X == i && pieces[k].Position.Y == j)
                    {
                        //
                        textBlocks[i, j].Text = pieces[k].Look.ToString();
                        break;
                    }
                }
            }
        }
    }

    void MouseClicked(object sender, MouseEventArgs e)
    {
        TextBlock s = (TextBlock)sender;
        //
        PointStruct p = findTexBlockCoordinates(s);
        //
        Title = "clicked";
        searchPiece(p);

        // coloring
        if (movedPiece != null)
        {
            // color Possible Moves
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    //
                    if (movedPiece.CanMove(new PointStruct(i, j)))
                    {
                        textBlocks[i, j].Background = Brushes.LightGoldenrodYellow;
                    }
                }
            }
        }
    }

    void MouseReleased(object sender, MouseEventArgs e)
    {
        TextBlock s = (TextBlock)sender;

        //
        PointStruct targetedPoint = findTexBlockCoordinates(s);
        // do temp copy of piece array
        // piecearray.copy;
        Title = "let go";

        // check if entered TextBlock is empty or not
        if (movedPiece != null)
        {
            if (movedPiece.MoveTo(targetedPoint))
            {
                DrawPieces();
            }
        }

        // compare both arrays for differences after movement
        // if(temp != currentpieceArray){
        // do stuff
        // playerswitch !
        //}
    }

    //void MouseEntered(object sender, MouseEventArgs e)
    //{
    //    TextBlock s = (TextBlock)sender;
    //    //
    //    PointStruct p = findTexBlockCoordinates(s);
    //    //
    //    searchPiece(p);

    //    if (movedPiece != null)
    //    {
    //        // color Possible Moves
    //        for (byte i = 0; i < 8; i++)
    //        {
    //            for (byte j = 0; j < 8; j++)
    //            {
    //                //
    //                if (movedPiece.CanMove(new PointStruct(i,j)))
    //                {
    //                    textBlocks[i, j].Background = Brushes.LightGoldenrodYellow;
    //                }
    //            }
    //        }
    //    }

    //}

    void MouseLeaved(object sender, MouseEventArgs e)
    {
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                textBlocks[i, j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
            }
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    PointStruct findTexBlockCoordinates(TextBlock s)
    {
        //
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                //
                if (textBlocks[i, j] == s)
                {
                    return new PointStruct(i, j);
                }
            }
        }
        // return Point
        return new PointStruct(0,0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    void searchPiece(PointStruct p)
    {
        // Find Piece to move
        for (byte i = 0; i < pieces.Length; i++)
        {
            //
            if (pieces[i].Position.X == p.X && pieces[i].Position.Y == p.Y)
            {
                movedPiece = pieces[i];
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Pieces[] InitialPieces()
    {
        Pieces[] pieces = new Pieces[32];

        // add rooks
        pieces[0] = new Rook(new PointStruct(0,7), false);
        pieces[1] = new Rook(new PointStruct(7, 7), false);
        pieces[2] = new Rook(new PointStruct(0, 0), true);
        pieces[3] = new Rook(new PointStruct(7, 0), true);
        // add bishops
        pieces[4] = new Bishop(new PointStruct(2, 7), false);
        pieces[5] = new Bishop(new PointStruct(5, 7), false);
        pieces[6] = new Bishop(new PointStruct(2, 0), true);
        pieces[7] = new Bishop(new PointStruct(5, 0), true);

        // add Kings
        pieces[8] = new King(new PointStruct(4, 7), false);
        pieces[9] = new King(new PointStruct(4, 0), true);
        
        // add Queens
        pieces[10] = new Queen(new PointStruct(3, 7), false);
        pieces[11] = new Queen(new PointStruct(3, 0), true);

        // add Knights
        pieces[12] = new Knight(new PointStruct(1, 7), false);
        pieces[13] = new Knight(new PointStruct(6, 7), false);
        pieces[14] = new Knight(new PointStruct(1, 0), true);
        pieces[15] = new Knight(new PointStruct(6, 0), true);
        
        // add Pawns
        pieces[16] = new Pawn(new PointStruct(0, 6), false);
        pieces[17] = new Pawn(new PointStruct(1, 6), false);
        pieces[18] = new Pawn(new PointStruct(2, 6), false);
        pieces[19] = new Pawn(new PointStruct(3, 6), false);
        pieces[20] = new Pawn(new PointStruct(4, 6), false);
        pieces[21] = new Pawn(new PointStruct(5, 6), false);
        pieces[22] = new Pawn(new PointStruct(6, 6), false);
        pieces[23] = new Pawn(new PointStruct(7, 6), false);
        pieces[24] = new Pawn(new PointStruct(0, 1), true);
        pieces[25] = new Pawn(new PointStruct(1, 1), true);
        pieces[26] = new Pawn(new PointStruct(2, 1), true);
        pieces[27] = new Pawn(new PointStruct(3, 1), true);
        pieces[28] = new Pawn(new PointStruct(4, 1), true);
        pieces[29] = new Pawn(new PointStruct(5, 1), true);
        pieces[30] = new Pawn(new PointStruct(6, 1), true);
        pieces[31] = new Pawn(new PointStruct(7, 1), true);

        return pieces;
    }
}

