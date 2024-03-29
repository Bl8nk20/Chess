﻿using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Windows.Documents;
using System.Windows.Media;

namespace OOP_Chess;

public class Player
{
    #region Properties
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
    private FEN_Startup FEN_Startup;

    private List<Piece> pieces;
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
    #endregion

    #region Constructor
    public Player(bool isWhite = false)
    {
        FEN_Startup = new FEN_Startup();
        this.isWhite = isWhite;
        this.isTurn = false;
        // create the pieces for the player
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

    #endregion

    #region Methods
    /// <summary>
    /// Switching Turns
    /// </summary>
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
        // Check if the piece belongs to the player and is allowed to move
        if (selectedPiece == null || selectedPiece.IsWhite != this.IsWhite || !this.IsTurn)
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
        // call fen class to convert a string in a list with the pieces
        List<Piece> CompleteFENList = FEN_Startup.ConvertStringToList();
        Pieces = new List<Piece>();
        // Looping for the complete list and search for own colored pieces
        foreach (Piece piece in CompleteFENList)
        {
            if (this.isWhite == piece.IsWhite)
            {
                Pieces.Add(piece);
            }
        }
        return Pieces;
    }

    /// <summary>
    /// Method to update the List with the 
    /// Pieces to remove the captured Piece
    /// looping for each element in the list and removing it
    /// , if the bool "IsKilled" is equal to true
    /// </summary>
    /// <param name="pieces">list with every pieces / current pieces in the game</param>
    public void updateList(List<Piece> pieces)
    {
        // looping and checking if any piece is lately updated
        foreach (var piece in pieces)
        {
            // check if bool variable is true and if so remove the piece from the board
            if (piece.IsKilled)
            {
                pieces.Remove(piece);
                break;
            }
        }
    }

    #region Piece Searching

    /// <summary>
    /// search the King of the current player
    /// </summary>
    /// <param name="currentPlayer"></param>
    /// <returns></returns>
    public Piece searchKing()
    {
        foreach (Piece piece in pieces)
        {
            if (piece is King)
            {
                return piece;
            }
        }

        return null;
    }

    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the List, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    internal Piece SearchPiece(PointStruct p)
    {
        // Find Piece to move
        foreach (var piece in pieces)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (piece.Position.Equals(p))
            {
                return piece;
            }
        }
        return null;
    }
    #endregion

    #endregion
}
