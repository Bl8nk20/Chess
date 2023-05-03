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
        if (Player1.IsTurn)
        {
            turn(Player1, TargetPoint);    
        }
        else if(Player2.IsTurn)
        {
            turn(Player2, TargetPoint);
        }

        // if everything is done switch turn sides
        Player1.SwitchTurns();
        Player2.SwitchTurns();
    }

    internal void turn(Player currentplayer, PointStruct TargetPoint)
    {

        if (!currentplayer.IsTurn)
        {
            return;
        }

        if (currentplayer.SelectedPiece.Position.Equals(TargetPoint))
        {
            return;
        }

        if (currentplayer.CanMove(Player1.SelectedPiece))
        {
            // move piece to targeted point
            currentplayer.SelectedPiece.MoveTo(TargetPoint, Pieces);
            Capture(currentplayer.SelectedPiece);

            // update list if needed
            currentplayer.updateList(Pieces);

        }
        // check if the game has ended
        isEnd();
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    internal List<Piece> InitialPieces()
    {
        // Looping for each player list to one list with both contents
        var pieces = new List<Piece>(Player1.Pieces.Count() + Player2.Pieces.Count());

        // loop through the pieces of each player to add them in a bigger list
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
        // looping through the list of pieces
        foreach (Piece piece in Pieces)
        {
            // check if the pieces collapsed and set they´re status to killed
            if(SelectedPiece.Position.Equals(piece.Position) && SelectedPiece.IsWhite != piece.IsWhite)
            {
                // check if the piece is a king piece
                if(piece is King)
                {
                    this.GAMESTATUS = GameStatus.WHITE_WIN;
                }
                piece.IsKilled = true;
                break;
            }
        }
    }
    /// <summary>
    /// checking for end state
    /// </summary>
    /// <returns></returns>
    public bool isEnd()
    {
        // return ether true or false
        return this.GAMESTATUS != GameStatus.ACTIVE;
    }

    #endregion
}
