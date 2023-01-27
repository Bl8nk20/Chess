using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Chess.Interfaces;

// a interface for the main Piece Logic as a blueprint.
internal interface IPieces
{
    /// <summary>
    /// a Method to check if the move the 
    /// user want to do is possible or not.
    /// For example if the move would go out of the board
    /// or out of the piece reach
    /// </summary>
    /// <returns>a true value if the user-movement is possible
    /// return a false value if the user-movement is not possible </returns>
    bool IsValidMove();

    /// <summary>
    /// a Method to get the basic movement of each piece
    /// for example: 
    /// a pawn can move one field forward and 
    ///        on its first movement 2 fields forward
    ///        the Pawn can throw diagonal only if there is a enemy piece
    /// </summary>
    bool Move(int xTarget, int yTarget);

    /// <summary>
    /// a Method to remove the piece from the 
    /// canvas and show it in the "graveyard"
    /// </summary>
    void Remove();
}

