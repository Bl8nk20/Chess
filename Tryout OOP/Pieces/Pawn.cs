using System;
using System.IO;

namespace Tryout_OOP;

public class Pawn : Pieces
{
    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Pawn(PointStruct Point, bool isWhite, bool isKilled)
        : base(Point, isWhite, isKilled, isWhite ? '\u2659' : '\u265F')
    {
        // empty Constructor cause nothing is needed :D
        // and also because everything is handed to the mother class
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
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        if(!this.isWhite)
        {
            return TargetPoint.Y == this.Position.Y - 1 && this.Position.X == TargetPoint.X;
        }
        // white Pawn movement
        if (hasMoved)
        {
            return TargetPoint.Y == this.Position.Y + 1 && this.Position.X == TargetPoint.X;
        }
        return TargetPoint.Y == this.Position.Y + 2 && this.Position.X == TargetPoint.X;
    }
}
