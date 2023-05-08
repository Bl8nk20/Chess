using System;
using System.Collections.Generic;

namespace Tryout_OOP;

public class Knight : Piece
{
    /// <summary>
    /// Constructor for the Rook Chesspiece
    /// </summary>
    /// <param name="x">Current X Coordinate</param>
    /// <param name="y">Current Y Coordinate</param>
    /// <param name="isWhite">Bool value if the Piece is White or not</param>
    public Knight(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite ? '\u2658' : '\u265E')
    {
        this.PieceValue = 3;
        // unicode: '\u2658' -> white Knight
        // unicode: '\u265E' -> black Knight
        // empty Constructor cause nothing is needed :D
    }

    /// <summary>
    /// Overwriting the Method to check if the Piece can Move according to the Rules
    /// Knight Movement : Product of X and Y must be 2
    /// </summary>
    /// <param name="xTarget">x - Coordinate</param>
    /// <param name="yTarget">y - Coordinate</param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        // the product of x and y must be equal to 2 
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);
        return x * y == 2;
    }
}
