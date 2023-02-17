using System;

namespace Tryout_OOP;

public class Bishop : Pieces
{
    /// <summary>
    /// Constructor for the Bishop Chesspiece
    /// </summary>
    /// <param name="x">Current X Coordinate</param>
    /// <param name="y">Current Y Coordinate</param>
    /// <param name="isWhite">Bool value if the Piece is White or not</param>
    public Bishop(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2657' : '\u265D')
    {
        // unicode: '\u2657' -> white Bishop
        // unicode: '\u265D' -> black Bishop
        // empty Constructor cause nothing is needed :D
    }

    /// <summary>
    /// Overwriting the Method to check if the Piece can Move according to the Rules
    /// Bishop Movement : Diagonal
    /// </summary>
    /// <param name="xTarget">x - Coordinate</param>
    /// <param name="yTarget">y - Coordinate</param>
    /// <returns></returns>
    public override bool CanMove(PointStruct TargetPoint)
    {
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);
        return x == y;
    }
}