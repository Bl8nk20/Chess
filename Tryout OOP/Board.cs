using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Tryout_OOP;

internal class Board
{
    Canvas Spielfeld;
    public List<TextBlock> TextBlocks;
    Game Game;

    public Board(Canvas spielfeld, List<TextBlock> textBlocks)
    {
        this.Game = new Game(); 
        this.Spielfeld = spielfeld;
        this.TextBlocks = textBlocks;
        DrawBoard();
    }

    /// <summary>
    /// a method to create the chessboard automatically 
    /// by generating 64 textblocks from a 2D array
    /// also add the chesspieces too if there are any to fill up
    /// </summary>
    internal void DrawBoard()
    {
        float size = 68.75F;
        // loop for each element of the 2d Array
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // create a new textblock each time
                TextBlock b = new TextBlock();

                b.Width = size;
                b.Height = size;
                b.FontSize = 45;
                b.Text = "*";
                b.TextAlignment = TextAlignment.Center;
                // color the textblock
                b.Foreground = Brushes.Black; // why is this? // DEFINITLY IMPORTANT
                b.Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                Spielfeld.Children.Add(b);
                Canvas.SetLeft(b, size * i);
                Canvas.SetBottom(b, size * j);
                b.MouseDown += MouseClicked;
                b.MouseUp += MouseReleased;
                // add the textblocks to a list
                TextBlocks.Add(b);
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
    /// <param name="Pieces">List with the pieces</param>
    /// <param name="TextBlocks">List with the TextBlock Elements </param>
    internal void DrawPieces(List<TextBlock> TextBlocks, List<Piece> Pieces)
    {
        // if the piece list is zero return nothing
        if (Pieces == null)
        {
            return;
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                // write an empty text inside
                TextBlocks[i * 8 + j].Text = "";
                foreach (var piece in Pieces)
                {
                    if (piece.Position.Equals(new PointStruct(i,j)))
                    {
                        // Write the Unicode Symbol and escape the for loop
                        TextBlocks[i * 8 + j].Text = piece.Look.ToString();
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
    public PointStruct findTexBlockCoordinates(TextBlock targetBlock, List<TextBlock> textBlock)
    {
        // looping for each element of the 2D-Array
        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                // if the TextBlock matches,
                // then return the X and Y Coordinate
                if (textBlock[i* 8 +j] == targetBlock)
                {
                    return new PointStruct(i, j);
                }
            }
        }
        // when nothing matches -> return Point
        return new PointStruct(0, 0);
    }

    /// <summary>
    /// Mouse clicked event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void MouseClicked(object sender, MouseEventArgs e)
    {
        // Clicked TextBlock
        TextBlock s = (TextBlock)sender;

        // finding the TextBlock Coordinates
        PointStruct p = findTexBlockCoordinates(s, TextBlocks);

        if (s != null)
        {
            Game.SetSelectedPiece(p);
        }
    }

    /// <summary>
    /// Mouse released event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void MouseReleased(object sender, MouseEventArgs e)
    {
        // Clicked TextBlock
        TextBlock s = (TextBlock)sender;

        // finding the TextBlock Coordinates
        PointStruct p = findTexBlockCoordinates(s, TextBlocks);
        // move the piece and after that draw it
        Game.playerMovement(p);
        DrawPieces(TextBlocks, Game.Pieces);
    }
}