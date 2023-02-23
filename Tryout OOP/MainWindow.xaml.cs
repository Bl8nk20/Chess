using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
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
        Logic logic = new Logic(pieces, textBlocks, movedPiece);
        pieces = logic.InitialPieces();
        DrawBoard();
        logic.Game();
    }

    void MouseClicked(object sender, MouseEventArgs e)
    {
        TextBlock s = (TextBlock)sender;
        // finding the TextBlock Coordinates
        PointStruct p = findTexBlockCoordinates(s);
        // Debugging
        //Title = "clicked";
        Logic logic = new Logic(pieces, textBlocks, movedPiece);

        // search for the Piece which is clicked
        // on an set the according piece
        movedPiece = logic.searchPiece(p);

        colorMovement();
    }

    void MouseReleased(object sender, MouseEventArgs e)
    {
        Capture capture = new Capture();
        TextBlock s = (TextBlock)sender;

        // Get TextBlock where the Mouse was clicked again 
        PointStruct targetedPoint = findTexBlockCoordinates(s);

        // do temp copy of piece array
        // piecearray.copy;

        // method for the Piece Movement
        // -> capturing and moving the piece
        pieceMoving(targetedPoint);

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
    /// a method to create the chessboard automatically 
    /// by generating 64 textblocks from a 2D array
    /// also add the chesspieces too if there are any to fill up
    /// </summary>
    private void DrawBoard()
    {
        // loop for each element of the 2d Array
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // create a new textblock each time
                TextBlock b = new TextBlock();
                // draw the chessboard
                b.Width = 72.5;
                b.Height = 72.5;
                b.FontSize = 45;
                // color the textblock
                b.Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                spielfeld.Children.Add(b);
                textBlocks[i, j] = b;
                Canvas.SetLeft(b, 72.5 * i);
                Canvas.SetBottom(b, 72.5 * j);
                // mouse button events
                b.MouseDown += MouseClicked;
                b.MouseUp += MouseReleased;
            }
        }

        // test if the piece can move
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
        // loop for each element of the 2d Array of textblocks
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // Write a empty String to the TextBlock
                textBlocks[i, j].Text = "";
                //search the List for a piece that fits
                foreach(var piece in pieces)
                { 
                    // Checking if the coodinates match up
                    if (piece.Position.X == i && piece.Position.Y == j)
                    {
                        // Write the Unicode Symbol and escape the for loop
                        textBlocks[i, j].Text = piece.Look.ToString();
                        break;
                    }
                }
            }
        }
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
    /// a method to help the player by coloring the positions,
    /// the chesspiece can move to 
    /// and to highlight the enemys, which could be attacked
    /// </summary>
    void colorMovement()
    {
        // checking if player clicked an empty textblock or not
        if (movedPiece == null)
        {
            return;
        }

        // looping for each element of the 2d array of textblocks
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

                // coloring the enemys / opponent pieces
                foreach (var piece in pieces)
                {
                    // if x and y ==
                    // AND enemy color
                    // AND Piece can move to that
                    //  then:
                    // color background
                    if (piece.Position.X == i
                        && piece.Position.Y == j
                        && movedPiece.IsWhite != piece.IsWhite
                        && movedPiece.CanMove(new PointStruct(i, j)))
                    {
                        textBlocks[i, j].Background = Brushes.IndianRed;
                    }

                    // checking the x and y is eqal
                    // AND own color
                    // AND piece can move to that
                    // then:
                    // remove the colored background
                    if (piece.Position.X == i
                        && piece.Position.Y == j
                        && movedPiece.IsWhite == piece.IsWhite
                        && movedPiece.CanMove(new PointStruct(i, j)))
                    {
                        textBlocks[i,j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                    }
                }
            }
        }
    }

    /// <summary>
    /// a method to get overlapping / same coordinates of pieces
    /// and removing them from the board and redraw them again
    /// </summary>
    void pieceMoving(PointStruct targetedPoint)
    {
        // Calling and setting up the Capture class
        Capture capture = new Capture();

        // check if entered TextBlock is empty or not
        if (movedPiece == null)
        {
            return;
        }

        // move the Piece and draw the Pieces again
        if (movedPiece.MoveTo(targetedPoint))
        {
            // set bool to true that the piece has moved already
            movedPiece.HasMoved = true;

            // looping for each element in the list
            foreach (var piece in pieces)
            {
                if(movedPiece is Pawn 
                    && (piece.Position.Equals(movedPiece.Position.X + 1)
                    || piece.Position.Equals(movedPiece.Position.X - 1))
                    && piece.IsWhite != movedPiece.IsWhite)
                {
                    // set the killed bool to true and break the loop
                    piece.IsKilled = true;
                    break;
                }
                // checking if the position of the moved piece
                // and a location of another piece is equal
                if (piece.Position.Equals(movedPiece.Position) && piece.IsWhite != movedPiece.IsWhite)
                {
                    // set the killed bool to true and break the loop
                    piece.IsKilled = true;
                    break;
                }
            }
            // updating the element list
            capture.updateList(pieces);
        }
        // draw the pieces again
        DrawPieces();
    }
}

