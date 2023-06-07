using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;

namespace Tryout_OOP;

public class Pawn : Piece
{
    public bool CanBePassed;
    public bool CanBePromoted;

    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Pawn(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2659' : '\u265F')
    {
        this.PieceValue = 1;
        this.CanBePassed = false;
        this.CanBePromoted = false;
        this.hasMoved = false;
    }

    public void SwitchCanBePassed()
    {
        CanBePassed = !CanBePassed;
    }


    /// <summary>
    /// Funktion istGültigerBauerzug(startFeld, zielfeld):
    ///     Wenn startFeld enthält einen Bauern:
    ///         Wenn zielfeld ist ein gültiges Feld und zielfeld ist leer:
    ///             Wenn der Bauer zieht ein Feld nach vorne:
    ///                 Rückgabe true
    ///         Sonst, wenn zielfeld enthält eine gegnerische Figur und ist ein diagonal angrenzendes Feld:
    ///             Rückgabe true
    ///     Rückgabe false
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Position.X - TargetPoint.X);
        int y = Math.Abs(this.Position.Y - TargetPoint.Y);

        // first time movement two steps foward
        if (y == 2 && x == 0 && !hasMoved)
        {
            // enpassant preparation
            CanBePassed = true;
            // IDK !?
            hasMoved = true;
            return true;
        }

        // first time movements single step forward
        if (!hasMoved && (y == 1 && x == 0))
        {
            hasMoved = true;
            return true;
        }

        // basic movement
        if (hasMoved || (y == 1 && x == 0))
        {
            hasMoved = true;
            return true;
        }

        // EnPassant
        //if (CapturePiece(TargetPoint, piece))
        //{
            
        //}
        
        //hasMoved = true;
        return false;
    }

    public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
    {

        // check the target location if there is a piece of same color
        foreach (var piece in pieces)
        {
            int x = Math.Abs(this.Position.X - piece.Position.X);
            int y = Math.Abs(this.Position.Y - piece.Position.Y);


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

            // EnPassant
            //if(piece is Pawn )
            //{
            //    CapturePiece(TargetPoint, (Pawn)piece);
            //}
        }
        hasMoved = true;

        return Movement(TargetPoint);
    }

    /// <summary>
    /// Funktion istSchlagzug(startFeld, zielfeld):
    ///     Wenn startFeld enthält einen Bauern:
    ///         Wenn zielfeld enthält eine gegnerische Figur und ist ein diagonal angrenzendes Feld:
    ///             Rückgabe true
    ///         Rückgabe false
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
    /// Funktion istEnPassant(ziehenderBauer, startFeld, zielfeld):
    ///     Wenn ziehenderBauer ist ein Bauer:
    ///         Wenn startFeld enthält einen Bauern und ziehendes Feld ist ein gültiges Feld:
    ///             Wenn ziehendes Feld ist das En-Passant-Ziel:
    ///                 Rückgabe true
    ///     Rückgabe false
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
