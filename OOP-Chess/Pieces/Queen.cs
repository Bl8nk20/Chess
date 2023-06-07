﻿using System;
using System.Collections.Generic;

namespace OOP_Chess;

public class Queen : Piece
{

    #region Constructor
    /// <summary>
    /// constructor for the Queen Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Queen(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite? '\u2655' : '\u265B')
    {
        // set the Piecevalue for the queen to 9
        this.PieceValue = 9;
    }
    #endregion

    #region Methods
    public override bool Movement(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        return TargetPoint.X == Point.X || TargetPoint.Y == Point.Y || x == y;
    }

    /// <summary>
    /// Check if the Movement is Diagonal
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    public bool MovementDiagonal(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        return x == y;
    }

    /// <summary>
    /// Check if the Movement is straight
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    public bool MovementStraight(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        return TargetPoint.X == Point.X || TargetPoint.Y == Point.Y;
    }

    /// <summary>
    /// Check if the Targetpoint is a viable movement by the queen
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <param name="pieces"></param>
    /// <param name="movedPiece"></param>
    /// <returns></returns>
    public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
    {
        // check the target location if there is a piece of same color
        foreach (var piece in pieces)
        {
            if (piece.Position.X == TargetPoint.X
                && piece.Position.Y == TargetPoint.Y
                && piece.IsWhite == isWhite)
            {
                return false;
            }
        }

        // check the way to the target location if it's in the first quadrant
        if (TargetPoint.X >= this.Point.X
            && TargetPoint.Y > this.Point.Y)
        {
            // check the way from the selected piece to the target if the move is possible
            for (int x = this.Point.X; x <= TargetPoint.X; x++)
            {
                for (int y = this.Point.Y + 1; y < TargetPoint.Y; y++)
                {
                    foreach (var piece in pieces)
                    {
                        if (piece.Position.X == x
                            && piece.Position.Y == y
                            && (MovementDiagonal(new PointStruct(x, y))
                            || MovementStraight(TargetPoint)))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // check the way to the target location if it's in the fourth quadrant
        if (TargetPoint.X > this.Point.X
            && TargetPoint.Y <= this.Point.Y)
        {
            // check the way from the selected piece to the target if the move is possible
            for (int x = this.Point.X + 1; x < TargetPoint.X; x++)
            {
                for (int y = this.Point.Y; y >= TargetPoint.Y; y--)
                {
                    foreach (var piece in pieces)
                    {
                        if (piece.Position.X == x
                            && piece.Position.Y == y
                            && (MovementDiagonal(new PointStruct(x, y))
                            || MovementStraight(TargetPoint)))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // check the way to the target location if it's in the third quadrant
        if (TargetPoint.X <= this.Point.X
            && TargetPoint.Y < this.Point.Y)
        {
            // check the way from the selected piece to the target if the move is possible
            for (int x = this.Point.X; x >= TargetPoint.X; x--)
            {
                for (int y = this.Point.Y - 1; y > TargetPoint.Y; y--)
                {
                    foreach (var piece in pieces)
                    {
                        if (piece.Position.X == x
                            && piece.Position.Y == y
                            && (MovementDiagonal(new PointStruct(x, y))
                            || MovementStraight(TargetPoint)))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        // check the way to the target location if it's in the second quadrant
        if (TargetPoint.X < this.Point.X
            && TargetPoint.Y >= this.Point.Y)
        {
            // check the way from the selected piece to the target if the move is possible
            for (int x = this.Point.X - 1; x > TargetPoint.X; x--)
            {
                for (int y = this.Point.Y; y <= TargetPoint.Y; y++)
                {
                    foreach (var piece in pieces)
                    {
                        if (piece.Position.X == x
                            && piece.Position.Y == y
                            && (MovementDiagonal(new PointStruct(x, y))
                            || MovementStraight(TargetPoint)))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return movedPiece.Movement(TargetPoint);
    }

    #endregion
}
