using System;
using System.Collections.Generic;
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
    public override bool CanMove(PointStruct TargetPoint, List<Pieces> pieces)
    {
        // checking if there is a piece of the same color on the TargetPoint
        foreach (var piece in pieces)
        {
            if (piece.Position.X == TargetPoint.X
            && piece.Position.Y == TargetPoint.Y
            && isWhite == piece.IsWhite)
            {
                return false;
            }
        }

        //int x = Math.Abs(this.Position.X - TargetPoint.X);
        //int y = Math.Abs(this.Position.Y - TargetPoint.Y);

        if (!this.isWhite && hasMoved)
        {
            // if pawn is NOT white but has moved already : 1 step "down"
            return TargetPoint.Y == this.Position.Y - 1 && this.Position.X == TargetPoint.X;
        }
        else if(!this.isWhite && !hasMoved)
        {
            // if pawn is NOT white and have NOT moved already : 2 step OR 1 step "down"
            return (TargetPoint.Y == this.Position.Y - 2
            && this.Position.X == TargetPoint.X)
            || (TargetPoint.Y == this.Position.Y - 1
            && this.Position.X == TargetPoint.X);
        }
        // white Pawn movement
        if (hasMoved)
        {
            return TargetPoint.X == Position.X && TargetPoint.Y == Position.Y + 1;
        }
        return ((TargetPoint.Y == this.Position.Y + 2
            && this.Position.X == TargetPoint.X)
            || (TargetPoint.Y == this.Position.Y + 1
            && this.Position.X == TargetPoint.X));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    bool CanCapturePiece(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Position.X - TargetPoint.X);
        int y = this.Position.Y - TargetPoint.Y;

        return x * y == -1;
    }
}
