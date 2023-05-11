using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
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
    #region PlayerTurnStuff
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
    }

    internal void turn(Player currentplayer, PointStruct TargetPoint)
    {
        // check if its the turn of the player
        if (!currentplayer.IsTurn)
        {
            return;
        }
        // check if piece has not moved
        // maybe need to use goto?
        if (currentplayer.SelectedPiece.Position.Equals(TargetPoint) || currentplayer.SelectedPiece == null)
        {
            return;
        }
        // check if player can move piece to his target
        if (currentplayer.CanMove(Player1.SelectedPiece))
        {
            // move piece to targeted point
            currentplayer.SelectedPiece.MoveTo(TargetPoint, Pieces, currentplayer.SelectedPiece);

            // ! Special Moves Like EnPassant, Castling, Promotion !
            currentplayer.specialMoves();

            // Capture Pieces
            Capture(currentplayer.SelectedPiece);

            // update list if needed
            currentplayer.updateList(Pieces);


            // if everything is done switch turn sides
            Player1.SwitchTurns();
            Player2.SwitchTurns();
        }
        // check if the game has ended
        if (isEnd())
        {
            MainWindow VictoryScreen = (MainWindow)Application.Current.MainWindow;
            // open the Victory Screen !
            // maybe switch case or own method to check who won 
        }

    }

    #endregion

    #region InitialPieces
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
    #endregion

    #region Piece Searching
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
    #endregion

    #region Capture
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
                // set the piece to killed
                piece.IsKilled = true;

                if(piece is King && piece.IsKilled)
                {
                    // set the gamestatuws to everything except active
                    GAMESTATUS = (piece.IsWhite) ? GameStatus.BLACK_WIN : GameStatus.WHITE_WIN;
                    // close window / show victory screen 
                    // MainWindow.Won();
                    // Show a messagebox to visualize victory
                    MessageBox.Show(GAMESTATUS.ToString());
                }
                // break to remove it later from the list
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

    #endregion
}
