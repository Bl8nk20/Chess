using System.Collections.Generic;

namespace Tryout_OOP;

public class Player
{
    private bool isWhite;
    public bool IsWhite
    {
        get { return isWhite; }
    }
    private bool isTurn;
    public bool IsTurn
    {
        set { isTurn = value; }
        get { return isTurn; }
    }

    private List<Piece>? pieces;
    public List<Piece> Pieces
    {
        get { return pieces; }
        set { pieces = value; }
    }

    private Piece selectedPiece;
    public Piece SelectedPiece
    {
        get { return selectedPiece; }
        set { selectedPiece = value; }
    }

    public Player(bool isWhite = false)
    {
        this.isWhite = isWhite;
        this.isTurn = false;
        Pieces = CreatePieces();
    }

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

    public void SwitchTurns()
    {
        isTurn = !isTurn;
    }

    /// <summary>
    /// Method to check if the Player is allowed
    /// to move the piece to that specific postion
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public bool CanMove(Piece piece)
    {
        if (selectedPiece == null)
        {
            return false;
        }
        // Check if the piece belongs to the player and is allowed to move
        if (selectedPiece.IsWhite != this.IsWhite)
        {
            return false;
        }
        if (!this.IsTurn)
        {
            return false;
        }
        // If all checks pass, the player can move the piece
        return true;
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    public List<Piece> CreatePieces()
    {
        List<Piece> pieces = new List<Piece>();

        // Create pawns
        for (int i = 0; i < 8; i++)
        {
            pieces.Add(new Pawn(new PointStruct(i, this.isWhite ? 1 : 6), this.isWhite));
        }

        // Create knights
        pieces.Add(new Knight(new PointStruct(1, this.isWhite ? 0 : 7), this.isWhite));
        pieces.Add(new Knight(new PointStruct(6, this.isWhite ? 0 : 7), this.isWhite));

        // Create bishops
        pieces.Add(new Bishop(new PointStruct(2, this.isWhite ? 0 : 7), this.isWhite));
        pieces.Add(new Bishop(new PointStruct(5, this.isWhite ? 0 : 7), this.isWhite));

        // Create rooks
        pieces.Add(new Rook(new PointStruct(0, this.isWhite ? 0 : 7), this.isWhite));
        pieces.Add(new Rook(new PointStruct(7, this.isWhite ? 0 : 7), this.isWhite));

        // Create Queen
        pieces.Add(new Queen(new PointStruct(3, this.isWhite ? 0 : 7), this.isWhite));

        // Create King
        pieces.Add(new King(new PointStruct(4, this.isWhite ? 0 : 7), this.isWhite));

        return pieces;
    }
}
