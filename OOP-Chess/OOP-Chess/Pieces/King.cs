using System;

namespace OOP_Chess;

public class King : Pieces
{
    // bool for the Castling movement if done
    private bool isCastlingDone = false;
    public bool IsCastlingDone
    {
        get { return isCastlingDone; }
        set { isCastlingDone = value; }
    }

    /// <summary>
    /// Constructor for the King Piece Class
    /// </summary>
    /// <param name="isWhite"></param>
    public King(bool isWhite) : base(isWhite)
    {

    }

    /// <summary>
    /// Overridden method for the King movement
    /// King Movement: 1 forward around the King
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool CanMove(Board board, Spot start, Spot end)
    {
        // we can't move the piece to a Spot that
        // has a piece of the same color
        if (end.Piece.IsWhite == this.IsWhite)
        {
            return false;
        }

        int x = Math.Abs(start.X - end.X);
        int y = Math.Abs(start.Y - end.Y);
        if (x + y == 1)
        {
            // check if this move will not result in the king
            // being attacked if so return true
            return true;
        }

        return this.isValidCastling(board, start, end);
    }

    /// <summary>
    /// check if the castlingmoevemnt is valid
    /// castling: rook not moved!
    ///           king not moved
    ///           knight and bishop out of the way
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    private bool isValidCastling(Board board,
                                    Spot start, Spot end)
    {
        // check if it has been done before
        if (this.isCastlingDone)
        {
            return false;
        }

        // Logic for returning true or false
        // implement it
        return false;
    }

    /// <summary>
    /// execute the castling moevement !
    /// IMPLEMENTION NEEDED !!!
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public bool isCastlingMove(Spot start, Spot end)
    {
        // check if the starting and
        // ending position are correct
        return false;
    }
}