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
<<<<<<< Updated upstream

=======
       
>>>>>>> Stashed changes
        return x + y == 1 || x * y == 1;
    }

    #endregion
}