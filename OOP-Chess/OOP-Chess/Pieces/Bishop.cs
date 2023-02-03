using System;

namespace OOP_Chess;

public class Bishop : Pieces
{
    /// <summary>
    /// constructor for the Bishop Piece Class
    /// </summary>
    /// <param name="isWhite"></param>
    public Bishop(bool isWhite) : base(isWhite)
    {

    }
    
    /// <summary>
    /// overridden method for the bishop movement
    /// Movement: diagonal x and y must be equal movement!
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
        return x / y == 1;
    }
}