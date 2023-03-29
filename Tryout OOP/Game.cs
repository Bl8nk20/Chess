using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    #region Properties
    GameStatus GAMESTATUS;
    GameMode GAMEMODE;
    Player Player1;
    Player Player2;
    public List<Piece> Pieces;
    #endregion

    #region Constructor
    public Game()
    {

        this.Player1 = new Player(true); // WHite Player
        Player1.IsTurn = true;
        this.Player2 = new Player(); // Black Player
        Player2.IsTurn = false;
        this.Pieces = InitialPieces();
    }
    #endregion

    #region Methods

    /// <summary>
    /// A method to set the selected piece according, which players turn is
    /// </summary>
    /// <param name="SelectedPoint"></param>
    public void SetSelectedPiece(PointStruct SelectedPoint)
    {
        if (Player1.IsTurn)
        {
            Player1.SelectedPiece = searchPiece(SelectedPoint);

        }
        else if ( Player2.IsTurn)
        {
            Player2.SelectedPiece = searchPiece(SelectedPoint);
        }
    }

    /// <summary>
    /// Method to check for the playerturn
    /// to check for the current player
    /// and from that get the turn
    /// </summary>
    public void playerMovement(PointStruct TargetPoint)
    {
        // check if the Gamestate has changed
        if (Player1.IsTurn)
        {
            CheckKingKill(Player1);
            // get movement call from player1
            if (Player1.CanMove(Player1.SelectedPiece))
            {
                // move piece to targeted point
                Player1.SelectedPiece.MoveTo(TargetPoint, Pieces);
                Capture(Player1.SelectedPiece);

                // update list if needed
                Player1.updateList(Pieces);

                // if everything is done switch turn sides
                Player1.SwitchTurns();
                Player2.SwitchTurns();
            }
        }
        else if(Player2.IsTurn)
        {
            CheckKingKill(Player2);
            // get movement call from player1
            if (Player2.CanMove(Player1.SelectedPiece))
            {
                Player2.SelectedPiece.MoveTo(TargetPoint, Pieces);
                Capture(Player2.SelectedPiece);

                // update list if needed
                Player2.updateList(Pieces);

                // if everything is done switch turn sides
                Player1.SwitchTurns();
                Player2.SwitchTurns();
            }
        }
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    internal List<Piece> InitialPieces()
    {
        // Looping for each player list to one list with both contents
        var pieces = new List<Piece>(Player1.Pieces.Count() + Player2.Pieces.Count());
        foreach (var item in Player1.Pieces)
        {
            pieces.Add(item);
        }
        foreach (var item in Player2.Pieces)
        {
            pieces.Add(item);
        }

        return pieces;
    }

    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the List, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    internal Piece searchPiece(PointStruct p)
    {
        // Find Piece to move
        foreach (var piece in Pieces)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (piece.Position.Equals(p))
            {
                return piece;
            }
        }
        return null;
    }

    /// <summary>
    /// Method for the capute logic
    /// needed: List of All Pieces
    ///         Locations of the Pieces
    ///         
    ///         Current Selected Piece
    ///         Location of Selected Piece
    ///         
    ///         Color of piece
    /// </summary>
    /// <param></param>
    internal void Capture(Piece SelectedPiece)
    {
        foreach (Piece piece in Pieces)
        {
            if(SelectedPiece.Position.Equals(piece.Position) && SelectedPiece.IsWhite != piece.IsWhite)
            {
                piece.IsKilled = true;
                break;
            }
        }
    }

    /// <summary>
    /// Checks if any King has been killed by looping over the List of pieces 
    /// and search for a piece of the type king and for the boolean value isKilled
    /// </summary>
    public void CheckKingKill(Player currentPlayer)
    {
        foreach (var piece in currentPlayer.Pieces)
        {
            if (piece.IsKilled && piece is King)
            {
                GAMESTATUS = currentPlayer.IsWhite ? GameStatus.BLACK_WIN : GameStatus.WHITE_WIN;
            }
        }
    }

    /// <summary>
    /// checking for end state
    /// </summary>
    /// <returns></returns>
    public bool isEnd()
    {
        return this.GAMESTATUS != GameStatus.ACTIVE;
    }

    #endregion
}
