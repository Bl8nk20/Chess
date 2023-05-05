using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Tryout_OOP;

namespace Tryout_OOP;

public class Rook : Piece
{

    #region Constructor
    /// <summary>
    /// Constructor for the Rook Chesspiece
    /// </summary>
    /// <param name="x">Current X Coordinate</param>
    /// <param name="y">Current Y Coordinate</param>
    /// <param name="isWhite">Bool value if the Piece is White or not</param>
    public Rook(PointStruct Point, bool isWhite)
        : base(Point, isWhite, isWhite? '\u2656' : '\u265C')
    {
        this.PieceValue = 5;
        // unicode: '\u2656' -> white Rook
        // unicode: '\u265C' -> black Rook
        // empty Constructor cause nothing is needed :D
    }
    #endregion

    #region Methods
    /// <summary>
    /// Overwriting the Method to check if the Piece can Move according to the Rules
    /// Rook Movement : Horizontal or Vertical
    /// </summary>
    /// <param name="xTarget">x - Coordinate</param>
    /// <param name="yTarget">y - Coordinate</param>
    /// <returns></returns>
    public override bool CanMove(PointStruct TargetPoint, List<Piece> pieces)
    {
        // checking if there is a piece of the same color on the TargetPoint
        foreach (var piece in pieces)
        {
            if (base.checkCondition(TargetPoint, piece))
            {
                return false;
            }
        }

        return TargetPoint.X == Position.X || TargetPoint.Y == Position.Y;
    }

    #endregion
}