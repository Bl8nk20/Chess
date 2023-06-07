using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace OOP_Chess;

public class Pawn : Piece
{
    // initializing a Property if the Pawn can be passed
    public bool CanBePassed;
    // initializing a Property if the Pawn can be Promoted
    public bool CanBePromoted;

    /// <summary>
    /// Constructor for the Pawn Chesspiece
    /// </summary>
    /// <param name="Point">Position of the Piece</param>
    /// <param name="isWhite"></param>
    public Pawn(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2659' : '\u265F')
    {
        // setting the Properties of the Pawn
        this.PieceValue = 1;
        this.CanBePassed = false;
        this.CanBePromoted = false;
        this.hasMoved = false;
    }

    /// <summary>
    /// Method to change the Property after the first two steps forward
    /// </summary>
    public void SwitchCanBePassed()
    {
        CanBePassed = !CanBePassed;
    }


    /// <summary>
    /// Movement Logic
    /// first time move and TargetPoint is in y +2 from current Position 
    /// -> return true and set properties CanBePassed and hasMoved to true
    /// first time move and TargetPoint is in y +1 from current Position
    /// -> return true and set property hasMoved to true
    /// every other move if TargetPoint is in y +1 
    /// -> return true
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Position.X - TargetPoint.X);
        int y = Math.Abs(this.Position.Y - TargetPoint.Y);

        // Black Pawn Movement
        if (!this.IsWhite && this.Position.Y < TargetPoint.Y)
        {
            return false;
        }

        if (!this.isWhite && hasMoved)
        {
            // if pawn is NOT white but has moved already : 1 step "down"
            return TargetPoint.Y == this.Position.Y - 1 && x == 0;
        }
        else if (!this.isWhite && !hasMoved)
        {
            // EnPassant Preparation
            if (y == 2)
            {
                CanBePassed = true;
            }
            hasMoved = true;
            // if pawn is NOT white and have NOT moved already : 2 step OR 1 step "down"
            return (y == 2
                && x == 0)
                || (y == 1
                && x == 0);
        }

        // white Pawn movement
        if(this.IsWhite && this.Position.Y > TargetPoint.Y)
        {
            return false;
        }

        // if pawn has moved and is white
        if (this.isWhite && hasMoved)
        {
            return TargetPoint.Y == Position.Y + 1 && x == 0;
        }

        // EnPassant Preparation
        if (y == 2)
        {
             CanBePassed = true;
        }

        hasMoved = true;

        return (y ==  2
            && x == 0)
            || (y == 1
            && x == 0);
    }

    /// <summary>
    /// Function Movement(TargetPoint):
    ///     If currentposition contains a Pawn:
    ///         If TargetPoint is a viable Space and TargetPoint is empty:
    ///             If Pawn moves one Space:
    ///                 return true
    ///         Else if TargetPoint contains an enemy Piece and is a diagonal Space:
    ///             return true
    ///     return false
    /// <param name="TargetPoint"></param>
    /// <param name="pieces"></param>
    /// <param name="movedPiece"></param>
    /// <returns></returns>
    public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
    {

        // check the target location if there is a piece of same color
        foreach (var piece in pieces)
        {
            // Basic Capturing
            if (CapturePiece(TargetPoint)
                && piece.Position.Equals(TargetPoint))
            {
                hasMoved = true;
                return true;
            }

            // Stop Movement if anybody is standing in front of them
            if (piece.Position.Equals(TargetPoint))
            {
                return false;
            }
        }
        hasMoved = true;
        // return the bool for every move done
        return Movement(TargetPoint);
    }

    /// <summary>
    /// Function CapturePiece(TargetPoint):
    ///     If currentPosition contains a Pawn:
    ///         If TargetPoint contains an enemy Piece and is a diagonal Space:
    ///             return true
    ///         return false
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <returns></returns>
    public bool CapturePiece(PointStruct TargetPoint)
    {
        // Whiteside Capturen
        if (this.isWhite
            && TargetPoint.Y == this.Position.Y + 1
            && (TargetPoint.X == this.Position.X + 1
            || TargetPoint.X == this.Position.X - 1))
        {
            return true;
        }

        // BlackSide Capturing
        if (!this.IsWhite
            && TargetPoint.Y == this.Position.Y - 1
            && (TargetPoint.X == this.Position.X + 1
            || TargetPoint.X == this.Position.X - 1))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Function IsEnpassant(TargetPoint, Pawn):
    ///     If CurrentPiece is a Pawn:
    ///         If currentPosition contains a Pawn AND Targetpoint is a viable Space:
    ///             If TargetPoint is EnPassantTarget:
    ///                 return true
    ///     return false
    ///     
    /// NOT REWRITTEN YET -> failed at basic movement
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <param name="pawn"></param>
    /// <returns></returns>
    public bool CapturePiece(PointStruct TargetPoint, Pawn pawn)
    {
        // Whiteside Capturen
        if (this.isWhite
            && pawn.CanBePassed
            && TargetPoint.Y == this.Position.Y + 1
            && (TargetPoint.X == this.Position.X + 1
            || TargetPoint.X == this.Position.X - 1))
        {
            return true;
        }

        // BlackSide Capturing
        if (!this.IsWhite
            && pawn.CanBePassed
            && TargetPoint.Y == this.Position.Y - 1
            && (TargetPoint.X == this.Position.X + 1
            || TargetPoint.X == this.Position.X - 1))
        {
            return true;
        }
        return false;
    }
}
