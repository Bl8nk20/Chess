using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryout_OOP;

public class Capture
{

    /// <summary>
    /// Method to update the List with the 
    /// Pieces to remove the captured Piece
    /// looping for each element in the list and removing it
    /// , if the bool "IsKilled" is equal to true
    /// </summary>
    /// <param name="pieces">list with every pieces / current pieces in the game</param>
    void updateList(List<Pieces> pieces)
    {
        foreach(var piece in pieces)
        {
            if (piece.IsKilled)
            {
                pieces.Remove(piece);
            }
        }
    }


}
