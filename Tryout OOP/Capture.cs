using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tryout_OOP;

public class Capture
{
    Pieces movedPiece;
    TextBlock[,] textBlocks = new TextBlock[8, 8];

    public Capture(Pieces movedPiece)
    {
        this.movedPiece = movedPiece;
    }

    /// <summary>
    /// Method to update the List with the 
    /// Pieces to remove the captured Piece
    /// looping for each element in the list and removing it
    /// , if the bool "IsKilled" is equal to true
    /// </summary>
    /// <param name="pieces">list with every pieces / current pieces in the game</param>
    public void updateList(List<Pieces> pieces)
    {
        foreach(var piece in pieces)
        {
            // check if bool variable is true and if so remove the piece from the board
            if (piece.IsKilled)
            {
                pieces.Remove(piece);
            }
        }
    }

    void capturing(List<Pieces> pieces)
    {

    }

}
