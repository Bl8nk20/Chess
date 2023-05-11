using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tryout_OOP;

/// <summary>
/// an abstract class to set a blueprint for each chesspiece
/// </summary>
public abstract class Piece
{
    #region Properties
    // not important at that stage of the development
    protected byte piecevalue;
    public byte PieceValue 
    { 
        get { return piecevalue; }
        set { piecevalue = value; }
    }

    // custom struct to create simplicity
    // and to store the coordinates / current positions
    protected PointStruct Point; 
    public PointStruct Position
    {
        get { return Point; }
        set { Point = value; }
    }

    // bool to check if piece is white
    // -> for player control
    protected bool isWhite;
    public bool IsWhite
    {
        get { return isWhite; }
    }

    // bool for checking if the piece has moved
    // and if so restict it to its "basic" movement
    protected bool hasMoved = false;
    public bool HasMoved
    {
        get { return hasMoved; }
        set { hasMoved = value; }
    }
    // bool for updating the list and removing any captured piece
    protected bool isKilled = false;
    public bool IsKilled
    {
        get { return isKilled; }
        set { isKilled = value; }
    }
    // bool for updating the list and removing any captured piece
    protected bool isUnderAttack = false;
    public bool IsUnderAttack
    {
        get { return isUnderAttack; }
        set { isUnderAttack = value; }
    }
    // unicode visuals
    protected char look; // unicode design currently
    public char Look
    {
        get { return look; }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Constructor for the Pieces.
    /// </summary>
    /// <param name="x">Current X Position</param>
    /// <param name="y">Current Y Position</param>
    /// <param name="isWhite">bool if piece is black or white</param>
    /// <param name="look">char for the Unicode Image</param>
    public Piece(PointStruct p, bool isWhite, char look)
    {
        this.Point = p;
        this.isWhite = isWhite;
        this.isKilled = isKilled | false;
        this.look = look;
    }
    #endregion

    #region Methods
    /// <summary>
    /// check the target point and the way to the target to see if movement is possible
    /// </summary>
    /// <param name="TargetPoint"></param>
    /// <param name="pieces"></param>
    /// <param name="movedPiece"></param>
    /// <returns> if the move is possible </returns>
    public virtual bool CanMove(PointStruct TargetPoint, List<Piece> pieces, Piece movedPiece)
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

            /*if (piece.isWhite != isWhite
                && piece.CanMove(King.Position, pieces, piece))
            {
                return false;
            }*/
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
                            && movedPiece.Movement(new PointStruct(x, y)))
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
                            && movedPiece.Movement(new PointStruct(x, y)))
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
                            && movedPiece.Movement(new PointStruct(x, y)))
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
                            && movedPiece.Movement(new PointStruct(x, y)))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return movedPiece.Movement(TargetPoint);
    }
    public abstract bool Movement(PointStruct Target);

    public bool MoveTo(PointStruct Target, List<Piece> pieces, Piece movedPiece)
    {
        // if the Move if false then returned False
        if (!CanMove(Target, pieces, movedPiece))
        {
            return false;
        }

        // if not false -> set targeted Coordinates and return true
        this.Position = Target;
        return true;
    }

    public void CancelMove(PointStruct lastLocation)
    {
        this.Position = lastLocation;
    }

    /// <summary>
    /// NOT IMPLEMENTED YET ! 
    /// IMPORTANT for the chessbot
    /// </summary>
    /// <returns></returns>
    byte setRelativePieceValue()
    {
        return byte.MaxValue;
    }

    #region Check Condition
    protected bool checkCondition(PointStruct TargetPoint, Piece enemyPiece)
    {
        return this.Position.Equals(TargetPoint) && isWhite == enemyPiece.IsWhite;
    }
    #endregion

    #endregion
}
