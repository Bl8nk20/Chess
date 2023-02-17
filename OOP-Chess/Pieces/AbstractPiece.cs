using System.Windows.Controls;

namespace OOP_Chess;

/// <summary>
/// an abstract class to set a blueprint for each chesspiece
/// </summary>
public abstract class Pieces
{
    protected byte x; // columns 0...7
    public byte X
    {
        get { return x; }
    }
    protected byte y; // rows 0...7, bottom is 0
    public byte Y
    {
        get { return y; }
    }
    protected bool isWhite;
    protected char look; // unicode design currently
    public char Look
    {
        get { return look; }
    }

    public Pieces(byte x, byte y, bool isWhite, char look)
    {
        this.x = x;
        this.y = y;
        this.isWhite = isWhite;
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
    public abstract bool CanMove(byte xTarget, byte yTarget);
}
