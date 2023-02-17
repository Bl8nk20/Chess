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
    List<Pieces> pieces = new List<Pieces>();
    Pieces movedPiece;

    public MainWindow()
    {
        InitializeComponent();
        pieces = InitialPieces();
        DrawBoard();
    }

    /// <summary>
    /// Method to Draw the Chessboard using 64 TextBlocks
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
            }
        }

        //pieces[0].MoveTo(new PointStruct(0, 4));
        
        // Draw Pieces / Update Pieces
        DrawPieces();
    }

    /// <summary>
    /// Method to Draw the Chesspieces 
    /// by checking if there is a piece 
    /// at the Same Coordinates of each Textblock
    /// then Draw the UniCode Symbol for the According ChessPiece
    /// else draw an empty String to the TextBlock
    /// </summary>
    void DrawPieces()
    {
        // Draw the ChessPieces
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // Write a empty String to the TextBlock
                textBlocks[i, j].Text = "";
                //search the Array for a piece that fits
                for (byte k = 0; k < pieces.Count; k++)
                {
                    // Checking if the coodinates match up
                    if (pieces[k].Position.X == i && pieces[k].Position.Y == j)
                    {
                        // Write the Unicode Symbol and escape the for loop
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
        // finding the TextBlock Coordinates
        PointStruct p = findTexBlockCoordinates(s);
        // Debugging
        //Title = "clicked";

        // search for the Piece which is clicked
        // on an set the according piece
        searchPiece(p);

        // coloring
        if (movedPiece != null)
        {
            // color Possible Moves
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    // check if the piece can move legally
                    if (movedPiece.CanMove(new PointStruct(i, j)))
                    {
                        // helping the Move Decision
                        // by coloring the Background in Yellow
                        textBlocks[i, j].Background = Brushes.LightGoldenrodYellow;
                    }
                }
            }
        }
    }

    void MouseReleased(object sender, MouseEventArgs e)
    {
        TextBlock s = (TextBlock)sender;

        // Get TextBlock where the Mouse was clicked again 
        PointStruct targetedPoint = findTexBlockCoordinates(s);

        // do temp copy of piece array
        // piecearray.copy;

        // debugging
        // Title = "let go";

        // check if entered TextBlock is empty or not
        if (movedPiece != null)
        {
            // move the Piece and draw the Pieces again
            if (movedPiece.MoveTo(targetedPoint))
            {
                DrawPieces();
            }
        }
        
        // coloring the Pieces back at its original colors
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                textBlocks[i, j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
            }
        }

        // compare both arrays for differences after movement
        // if(temp != currentpieceArray){
        // do stuff
        // playerswitch !
        //}
    }

    
    /// <summary>
    /// A method to find the Textblock 
    /// which is clicked 
    /// and where the mouse was released afterwards
    /// </summary>
    /// <param name="s"></param>
    /// <returns>the custom Struct "Pointstruct" with both the X and Y Coordinate</returns>
    PointStruct findTexBlockCoordinates(TextBlock s)
    {
        // looping for each element of the 2D-Array
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // if the TextBlock matches,
                // then return the X and Y Coordinate
                if (textBlocks[i, j] == s)
                {
                    return new PointStruct(i, j);
                }
            }
        }
        // when nothing matches -> return Point
        return new PointStruct(0,0);
    }

    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the Array, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    void searchPiece(PointStruct p)
    {
        // Find Piece to move
        for (byte i = 0; i < pieces.Count; i++)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (pieces[i].Position.X == p.X && pieces[i].Position.Y == p.Y)
            {
                movedPiece = pieces[i];
            }
        }
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    List<Pieces> InitialPieces()
    {
        List<Pieces> pieces = new List<Pieces>();

        // add white pieces
        // add white Pawns
        for(byte i = 0; i < textBlocks.GetLength(0); i++)
        {
            pieces.Add(new Pawn(new PointStruct(i, 1), true, false));

        }
        // add white Knights
        pieces.Add(new Knight(new PointStruct(1, 0), true, false));
        pieces.Add(new Knight(new PointStruct(6, 0), true, false));

        // add white Bishops
        pieces.Add(new Bishop(new PointStruct(2, 0), true, false));
        pieces.Add(new Bishop(new PointStruct(5, 0), true, false));

        // add white Rooks
        pieces.Add(new Rook(new PointStruct(0, 0), true, false));
        pieces.Add(new Rook(new PointStruct(7, 0), true, false));
        
        // add white Queen
        pieces.Add(new Queen(new PointStruct(3, 0), true, false));

        // add White King
        pieces.Add(new King(new PointStruct(4, 0), true, false));

        // add black pieces
        // add Pawns
        for (byte i = 0; i < textBlocks.GetLength(0); i++)
        {
            pieces.Add(new Pawn(new PointStruct(i, 6), false, false));

        }

        // add Black Knights
        pieces.Add(new Knight(new PointStruct(1, 7), false, false));
        pieces.Add(new Knight(new PointStruct(6, 7), false, false));

        // add Black Bishops
        pieces.Add(new Bishop(new PointStruct(2, 7), false, false));
        pieces.Add(new Bishop(new PointStruct(5, 7), false, false));
        
        // add black Rooks
        pieces.Add(new Rook(new PointStruct(0, 7), false, false));
        pieces.Add(new Rook(new PointStruct(7, 7), false, false));

        // add Queens
        pieces.Add(new Queen(new PointStruct(3, 7), false, false));

        // add Kings
        pieces.Add(new King(new PointStruct(4, 7), false, false));

        return pieces;
    }
}

