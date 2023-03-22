using System.Collections.Generic;
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
    /// Assumption: xTarget and yTarget always above 0
    /// Assumption: Targeted Point != StartingPoint
    /// Assumption: Nobody nearby/ in the way
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>move is valid</returns>
    public abstract bool CanMove(PointStruct Target, List<Piece> pieces);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Target"></param>
    /// <param name="pieces"></param>
    /// <returns></returns>
    public bool MoveTo(PointStruct Target, List<Piece> pieces)
    {
        // if the Move if false then returned False
        if (!CanMove(Target, pieces))
        {
            return false;
        }

        // if not false -> set targeted Coordinates and return true
        this.Position = Target;
        // Try to implement
        // PlayerTurn.Counter++;
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    byte setRelativePieceValue()
    {
        return byte.MaxValue;
    }
    #endregion
}
