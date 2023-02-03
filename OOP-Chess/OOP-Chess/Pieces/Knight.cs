using System;

namespace OOP_Chess;

public class Knight : Pieces
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="white"></param>
    public Knight(bool isWhite) : base(isWhite)
    {

    }

    /// <summary>
    /// overridden method to generate / ceck the movement of the Knight class
    /// knight movement : y +=2 && x +=1 || y+=1 && x*=2
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

        // the product of x and y must be equal to 2 
        int x = Math.Abs(start.X - end.X);
        int y = Math.Abs(start.Y - end.Y);
        return x * y == 2;
    }
}
