using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Tryout_OOP
{

    internal class Board
    {

        public Board()
        {
        }

        /// <summary>
        /// a method to create the chessboard automatically 
        /// by generating 64 textblocks from a 2D array
        /// also add the chesspieces too if there are any to fill up
        /// </summary>
        internal void DrawBoard(TextBlock[,] TextBlock)
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
                    TextBlock[i, j] = b;
                    Canvas.SetLeft(b, 72.5 * i);
                    Canvas.SetBottom(b, 72.5 * j);
                    // mouse button events
                    b.MouseDown += MouseClicked;
                    b.MouseUp += MouseReleased;
                }
            }
        }

        /// <summary>
        /// Method to Draw the Chesspieces 
        /// by checking if there is a piece 
        /// at the Same Coordinates of each Textblock
        /// then Draw the UniCode Symbol for the According ChessPiece
        /// else draw an empty String to the TextBlock
        /// </summary>
        internal void DrawPieces(TextBlock[,] TextBlock, List<Piece> Pieces)
        {
            if (Pieces == null)
            {
                return;
            }

            // loop for each element of the 2d Array of textblocks
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    // Write a empty String to the TextBlock
                    TextBlock[i, j].Text = "";
                    //search the List for a piece that fits
                    foreach (var piece in Pieces)
                    {
                        // Checking if the coodinates match up
                        if (piece.Position.X == i && piece.Position.Y == j)
                        {
                            // Write the Unicode Symbol and escape the for loop
                            TextBlock[i, j].Text = piece.Look.ToString();
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
        internal PointStruct findTexBlockCoordinates(TextBlock targetBlock)
        {
            // looping for each element of the 2D-Array
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    // if the TextBlock matches,
                    // then return the X and Y Coordinate
                    if (TextBlock[i, j] == targetBlock)
                    {
                        return new PointStruct(i, j);
                    }
                }
            }
            // when nothing matches -> return Point
            return new PointStruct(0, 0);
        }

        /*
        
        
        /// <summary>
        /// a method to get overlapping / same coordinates of pieces
        /// and removing them from the board and redraw them again
        /// </summary>
        public void pieceMoving(PointStruct targetedPoint)
        {
            // Calling and setting up the Capture class
            Capture capture = new Capture();

            // check if entered TextBlock is empty or not
            if (movedPiece == null)
            {
                return;
            }

            // move the Piece and draw the Pieces again
            if (movedPiece.MoveTo(targetedPoint, Pieces))
            {
                // set bool to true that the piece has moved already
                movedPiece.HasMoved = true;

                // looping for each element in the list
                foreach (var piece in Pieces)
                {
                    if (movedPiece is Pawn
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

                // Show the Current turn !
                //TextBlockTurns.Text = ToString();
                // updating the element list
                capture.updateList(Pieces);
            }
            // draw the pieces again
            DrawPieces();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseClicked(object sender, MouseEventArgs e)
        {
            Coloring_Movement coloring = new Coloring_Movement(TextBlock, Pieces, movedPiece);
            TextBlock s = (TextBlock)sender;
            // finding the TextBlock Coordinates
            PointStruct p = findTexBlockCoordinates(s);

            // 
            AdditionalLogic Logic = new AdditionalLogic(Pieces, TextBlock, movedPiece);

            // search for the Piece which is clicked
            // on an set the according piece
            movedPiece = Logic.searchPiece(p);

            //
            coloring.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MouseReleased(object sender, MouseEventArgs e)
        {
            TextBlock s = (TextBlock)sender;

            // Get TextBlock where the Mouse was clicked again 
            PointStruct targetedPoint = findTexBlockCoordinates(s);

            // method for the Piece Movement
            // -> capturing and moving the piece
            pieceMoving(targetedPoint);

            // coloring the Pieces back at its original colors
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    TextBlock[i, j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                }
            }
        }
        */
    }
}