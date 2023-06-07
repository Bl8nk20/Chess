using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace OOP_Chess;

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
        // setting the PieceValue to the max Value of a byte,
        // that the AI can later search for the highest value move
        this.PieceValue = byte.MaxValue;
        // unicode: '\u2654' -> white King
        // unicode: '\u265A' -> black King
    }
    #endregion

    #region Methods
    /// <summary>
    /// Overridden method for the King movement
    /// King Movement: 1 forward around the King
    /// </summary>
    /// <param name="TargetPoint">Point where the King wants to move</param>
    /// <returns></returns>
    public override bool Movement(PointStruct TargetPoint)
    {
        // calculate the Absolute value of the difference of the current position and the targetpoint
        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);

        // return either true if the sum OR the product is eqal 1
        return x + y == 1 || x * y == 1;
    }

    #endregion
}