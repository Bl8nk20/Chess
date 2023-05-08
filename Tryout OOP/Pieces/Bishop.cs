using System;
using System.Collections.Generic;

namespace Tryout_OOP;

public class Bishop : Piece
{
    #region Constructor
    /// <summary>
    /// Constructor for the Bishop Chesspiece
    /// </summary>
    /// <param name="x">Current X Coordinate</param>
    /// <param name="y">Current Y Coordinate</param>
    /// <param name="isWhite">Bool value if the Piece is White or not</param>
    public Bishop(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2657' : '\u265D')
    {
        this.PieceValue = 3;
        // unicode: '\u2657' -> white Bishop
        // unicode: '\u265D' -> black Bishop
        // empty Constructor cause nothing is needed :D
    }
    #endregion

    #region Methods
    /// <summary>
    /// Overwriting the Method to check if the Piece can Move according to the Rules
    /// Bishop Movement : Diagonal
    /// </summary>
    /// <param name="xTarget">x - Coordinate</param>
    /// <param name="yTarget">y - Coordinate</param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        return (x == y);
    }

    #region Check Condition
    bool checkCondition(Piece piece, PointStruct TargetPoint)
    {
        return piece.Position.Equals(TargetPoint) && isWhite == piece.IsWhite;
    }
    #endregion

    #endregion
}