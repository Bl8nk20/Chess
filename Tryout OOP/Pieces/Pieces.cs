using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Tryout_OOP;

/// <summary>
/// an abstract class to set a blueprint for each chesspiece
/// </summary>
public abstract class Pieces
{
    // custom struct to creat simplicity
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
    // unicode visuals
    protected char look; // unicode design currently
    public char Look
    {
        get { return look; }
    }

    /// <summary>
    /// Constructor for the Pieces.
    /// </summary>
    /// <param name="x">Current X Position</param>
    /// <param name="y">Current Y Position</param>
    /// <param name="isWhite">bool if piece is black or white</param>
    /// <param name="look">char for the Unicode Image</param>
    public Pieces(PointStruct p, bool isWhite, bool isKilled, char look)
    {
        this.Point = p;
        this.isWhite = isWhite;
        this.isKilled = isKilled;
        this.look = look;
    }

    // \u => unicode
    // \u2654 => white king
    // \u2655 => white Queen
    // \u2656 => white rook
    // \u2657 => white bishop
    // \u2658 => white knight
    // \u2659 => white pawn
    // \u265A => black King
    // \u265B => black Queen
    // \u265C => black Rook
    // \u265D => black bishop
    // \u265E => black knight
    // \u265F => black Pawn

    /// <summary>
    /// Assumption: xTarget and yTarget always above 0
    /// Assumption: Targeted Point != StartingPoint
    /// Assumption: Nobody nearby/ in the way
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>move is valid</returns>
    public abstract bool CanMove(PointStruct Target, List<Pieces> pieces);
    public bool MoveTo(PointStruct Target, List<Pieces> pieces)
    {
        // if the Move if false then returned False
        if (!CanMove(Target, pieces))
        {
            return false;
        }

        // if not false -> set targeted Coordinates and return true
        this.Position = Target;
        return true;
    }
}
