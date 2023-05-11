using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Tryout_OOP;

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

    #region Special Moves
    /// <summary>
    /// a method to validate if certain moves are valid
    /// e.g. En passant or Castling or Promoting
    /// </summary>
    internal void specialMoves()
    {
        foreach (var piece in pieces)
        {
            // En Passant:
            // check if movedPiece is from type Pawn
            // check if on the left or right is another (enemy) pawn
            // check if he has moved two forward
            // throw diagonally
            if (SelectedPiece is Pawn && (piece.Position.Equals(new PointStruct(SelectedPiece.Position.Y, SelectedPiece.Position.X + 1))
                                       || piece.Position.Equals(new PointStruct(SelectedPiece.Position.Y, SelectedPiece.Position.X - 1))))
            {

            }

            // Castling
            // check if movedPiece is from type King
            // check if king and one of the Rooks haven´t been moved yet
            // check if the way is free (no bishop or knight or other piece is on same line)
            // move king two steps in rooks direction -> place rook on the left or right nearby
            // set king and rook to moved
            if (SelectedPiece is King && SelectedPiece.HasMoved == false)
            {

            }

            // Promotion
            // check if pawn has reached end of board
            // ask player to which piece the pawn should be promoted
            // remove pawn -> replace it with players choice
            if (SelectedPiece is Pawn)
            {
                Promotion();
            }
        }

        #region Promotion
        void Promotion()
        {
            MainWindow Promotion = (MainWindow)Application.Current.MainWindow;
            /* 
             * First check if a pawn is at the end of the board
             * then open the promotion window
             */

            // check if its black or white
            if (!SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 0)))
            {
                // Window
                //Promotion.promationContentB();
                // piece needed to replace either with the user input or a specific piece
                SelectedPiece.IsKilled = true;
                //pieces.Add(new ...(movedPiece.Position));

            }

            if (SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 7)))
            {
                // Window
                //Promotion.promationContentW();

                // piece needed to replace either with the user input or a specific piece
                SelectedPiece.IsKilled = true;
                //pieces.Add(new ...(movedPiece.Position));

            }
        }


    }
    #endregion
    #endregion

    #endregion
}
