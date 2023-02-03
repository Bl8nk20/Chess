using System;

namespace OOP_Chess;

public class Queen : Pieces
{

    /// <summary>
    /// constructor for the Queen Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Queen(bool isWhite) : base(isWhite)
    {

    }

    /// <summary>
    /// overridden method for the Queen movement
    /// movement for queen: basically bishop and rook movement
    ///                     diagonal
    ///                     horizontal 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool CanMove(Board board, Spot start, Spot end)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour
        if (end.Piece.IsWhite == this.IsWhite)
        {
            return false;
        }

        int x = Math.Abs(start.X - end.X);
        int y = Math.Abs(start.Y - end.Y);

        return end.Y == start.Y
            || end.X == start.X
            || x / y == 1;
    }
}
