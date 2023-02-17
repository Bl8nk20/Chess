using System;

namespace OOP_Chess;

public class Knight : Pieces
{
    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Knight(byte x, byte y, bool isWhite)
        : base(x, y, isWhite, isWhite ? '\u2656' : '\u265C')
    {
        // empty Constructor cause nothing is needed :D
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool CanMove(byte xTarget, byte yTarget)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour

        return xTarget == x || yTarget == y;
    }
    /// <summary>
    /// overridden method to generate / ceck the movement of the Knight class
    /// knight movement : y +=2 && x +=1 || y+=1 && x*=2
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    //public override bool CanMove(Board board, Spot start, Spot end)
    //{
    //    // we can't move the piece to a spot that has
    //    // a piece of the same colour
    //    if (end.Piece.IsWhite == this.IsWhite)
    //    {
    //        return false;
    //    }

    //    // the product of x and y must be equal to 2 
    //    int x = Math.Abs(start.X - end.X);
    //    int y = Math.Abs(start.Y - end.Y);
    //    return x * y == 2;
    //}
}
