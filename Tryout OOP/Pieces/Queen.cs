using System;

namespace Tryout_OOP;

public class Queen : Pieces
{

    /// <summary>
    /// constructor for the Queen Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Queen(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2655' : '\u265B')
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
    public override bool CanMove(PointStruct TargetPoint)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour

        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);
       
        return TargetPoint.X == Point.X || TargetPoint.Y == Point.Y || x == y;
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
    //public override bool CanMove(Board board, Spot start, Spot end)
    //{
    //    // we can't move the piece to a spot that has
    //    // a piece of the same colour
    //    if (end.Piece.IsWhite == this.IsWhite)
    //    {
    //        return false;
    //    }

    //    int x = Math.Abs(start.X - end.X);
    //    int y = Math.Abs(start.Y - end.Y);

    //    return end.Y == start.Y
    //        || end.X == start.X
    //        || x / y == 1;
    //}
}
