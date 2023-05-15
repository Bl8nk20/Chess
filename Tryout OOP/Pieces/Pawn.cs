using System;
using System.Collections.Generic;
using System.IO;

namespace Tryout_OOP;

public class Pawn : Piece
{
    private bool canBePassed;
    public bool CanBePassed;

    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Pawn(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2659' : '\u265F')
    {
        this.PieceValue = 1;
        this.canBePassed = false;
        // empty Constructor cause nothing is needed :D
        // and also because everything is handed to the mother class
    }

    public void SwitchCanBePassed()
    {
        canBePassed = !canBePassed;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        //int x = Math.Abs(this.Position.X - TargetPoint.X);
        //int y = Math.Abs(this.Position.Y - TargetPoint.Y);

        if (!this.isWhite && hasMoved)
        {
            // if pawn is NOT white but has moved already : 1 step "down"
            return TargetPoint.Y == this.Position.Y - 1 && this.Position.X == TargetPoint.X;
        }
        else if (!this.isWhite && !hasMoved)
        {
            // if pawn is NOT white and have NOT moved already : 2 step OR 1 step "down"
            return TargetPoint.Equals(new PointStruct(this.Position.X, this.Position.Y - 2))
                || TargetPoint.Equals(new PointStruct(this.Position.X, this.Position.Y - 1));
        }
        // white Pawn movement
        if (hasMoved)
        {
            return TargetPoint.X == Position.X && TargetPoint.Y == Position.Y + 1;
        }
        return TargetPoint.Equals(new PointStruct(this.Position.X, this.Position.Y + 2))
            || TargetPoint.Equals(new PointStruct(this.Position.X, this.Position.Y + 1));
    }

    public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
    {
        // check the target location if there is a piece of same color
        foreach (var piece in pieces)
        {
            if (piece.Position.Equals(TargetPoint)
                && piece.IsWhite == isWhite)
            {
                return false;
            }
        }

        foreach (var piece in pieces)
        {
            if (CapturePiece(TargetPoint)
                && piece.Position.X == TargetPoint.X
                && piece.Position.Y == TargetPoint.Y)
            {
                return true;
            }

            if (piece.Position.Equals(TargetPoint))
            {
                return false;
            }
        }

        return Movement(TargetPoint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    public bool CapturePiece(PointStruct TargetPoint)
    {
        if (this.isWhite
            && TargetPoint.Y == this.Position.Y + 1
            && (TargetPoint.X == this.Point.X + 1
            || TargetPoint.X == this.Point.X - 1))
        {
            return true;
        }

        if (!this.IsWhite
            && TargetPoint.Y == this.Point.Y - 1
            && (TargetPoint.X == this.Point.X + 1
            || TargetPoint.X == this.Point.X - 1))
        {
            return true;
        }

        return false;
    }
}
