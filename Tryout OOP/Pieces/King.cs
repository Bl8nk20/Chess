using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Tryout_OOP;

public class King : Piece
{
    #region Properties
    // bool for the Castling movement if done
    private bool isCastlingDone = false;
    public bool IsCastlingDone
    {
        get { return isCastlingDone; }
        set { isCastlingDone = value; }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Constructor for the King Chesspiece
    /// </summary>
    /// <param name="x">Current X Coordinate</param>
    /// <param name="y">Current Y Coordinate</param>
    /// <param name="isWhite">Bool value if the Piece is White or not</param>
    public King(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2654' : '\u265A')
    {
        this.PieceValue = byte.MaxValue;
        // unicode: '\u2654' -> white King
        // unicode: '\u265A' -> black King
        // empty Constructor cause nothing is needed :D
    }
    #endregion

    #region Methods
    /// <summary>
    /// Overridden method for the King movement
    /// King Movement: 1 forward around the King
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);
        return x + y == 1 || x * y == 1;
    }


    /*public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
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

        foreach (var piece in pieces)
        {
            if (piece.IsWhite != isWhite)
            {
                if (!(piece is Pawn)
                    && piece.CanMove(TargetPoint, pieces, piece))
                {
                    return false;
                }

                if (piece is Pawn
                    && piece.CapturePiece(TargetPoint))
                {
                    return false;
                }
            }
        }

        return Movement(TargetPoint);
    }*/

    #region Castling Methods (WIP)
    /// <summary>
    /// check if the castlingmoevemnt is valid
    /// castling: rook not moved!
    ///           king not moved
    ///           knight and bishop out of the way
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    //private bool isValidCastling(Board board,
    //                                Spot start, Spot end)
    //{
    //    // check if it has been done before
    //    if (this.isCastlingDone)
    //    {
    //        return false;
    //    }

    //    // Logic for returning true or false
    //    // implement it
    //    return false;
    //}

    /// <summary>
    /// execute the castling moevement !
    /// IMPLEMENTION NEEDED !!!
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    //public bool isCastlingMove(Spot start, Spot end)
    //{
    //    // check if the starting and
    //    // ending position are correct
    //    return false;
    //}
    #endregion

    #endregion
}