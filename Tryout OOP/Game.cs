using System;
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
    public List<Piece> Pieces;
<<<<<<< HEAD
    Player[] players;
=======
    MainWindow wnd = (MainWindow)Application.Current.MainWindow;

>>>>>>> main
    #endregion

    #region Constructor
    public Game()
    {
        this.players = new Player[2];
        this.players[0] = new Player(true); // White Player
        players[0].IsTurn = true;
        this.players[1] = new Player(); // Black Player
        players[1].IsTurn = false;
        this.Pieces = InitialPieces();
    }
    #endregion

    #region Methods

    #region PlayerTurnStuff

    /// <summary>
    /// Method to set the current Player
    /// with shortened boolean writing
    /// </summary>
    /// <returns></returns>
    private Player setCurrentPlayer()
    {
        return (players[0].IsTurn) ? players[0] : players[1];
    }

    /// <summary>
    /// A method to set the selected piece according, which players turn is
    /// </summary>
    /// <param name="SelectedPoint"></param>
    public void SetSelectedPiece(PointStruct SelectedPoint)
    {
        if (players[0].IsTurn)
        {
<<<<<<< HEAD
            players[0].SelectedPiece = players[0].SearchPiece(SelectedPoint);
=======
            Player1.SelectedPiece = searchPiece(SelectedPoint);
            wnd.TurnWhite();
>>>>>>> main

        }
        else if (players[1].IsTurn)
        {
<<<<<<< HEAD
            players[1].SelectedPiece = players[1].SearchPiece(SelectedPoint);
=======
            Player2.SelectedPiece = searchPiece(SelectedPoint);
            wnd.TurnBlack();

>>>>>>> main
        }
    }

    /// <summary>
    /// Method to check for the playerturn
    /// to check for the current player
    /// and from that get the turn
    /// </summary>
    public void playerMovement(PointStruct TargetPoint)
    {
        // Set the current player
        Player currentPlayer = setCurrentPlayer();

        // TurnLogic chess
        turn(currentPlayer, TargetPoint);
    }


    /// <summary>
    /// Internal Logic for the turns in chess
    /// </summary>
    /// <param name="currentplayer"></param>
    /// <param name="TargetPoint"></param>
    internal void turn(Player currentplayer, PointStruct TargetPoint)
    {
        if (currentplayer.SelectedPiece is King && Math.Abs(TargetPoint.X - currentplayer.SelectedPiece.Position.X) > 1)
        {
            // ! Special Moves Like EnPassant, Castling, Promotion !
            currentplayer.Castling(currentplayer.SelectedPiece, TargetPoint);

            // if everything is done switch turn sides
            players[0].SwitchTurns();
            players[1].SwitchTurns();
        }
        // En Passant Switching if a Pawn is "Passable"
        foreach (var piece in currentplayer.Pieces)
        {
            // skip pieces which are not a Pawn
            if (piece is not Pawn)
            {
                continue;
            }

            Pawn pawn = (Pawn)piece;
            if (!pawn.CanBePassed)
            {
                continue;
            }
            pawn.SwitchCanBePassed();
        }

        // check if its the turn of the player and if he selected a piece
        if (!currentplayer.IsTurn
            || currentplayer.SelectedPiece == null)
        {
            return;
        }

        // check if piece has not moved
        // maybe need to use goto?
        if (currentplayer.SelectedPiece.Position.Equals(TargetPoint)
            || !currentplayer.SelectedPiece.CanMove(TargetPoint, Pieces, currentplayer.SelectedPiece))
        {
            return;
        }

        // Castling Opportunity ? 
        if (currentplayer.SelectedPiece is King)
        {
            // Castling
            currentplayer.Castling(currentplayer.SelectedPiece, TargetPoint);
        }

        // check if player can move piece to his target
        if (currentplayer.CanMove(currentplayer.SelectedPiece))
        {
            // save last location to cancel a false move
            PointStruct lastLocation = currentplayer.SelectedPiece.Position;

            
            // move piece to targeted point
            currentplayer.SelectedPiece.MoveTo(TargetPoint, Pieces, currentplayer.SelectedPiece);

            // Capture Pieces
            Capture(currentplayer.SelectedPiece);

            // check if any enemy piece can move to current players king to check if the move is legit
            foreach (var piece in Pieces)
            {
                if (piece.IsWhite != currentplayer.IsWhite
                    && piece.CanMove(currentplayer.searchKing().Position, Pieces, piece))
                {
                    currentplayer.SelectedPiece.Move(lastLocation);
                    return;
                }
            }

            // Switch EnPassant Possibility
            if (currentplayer.SelectedPiece is Pawn
                && (currentplayer.SelectedPiece.Position.Equals(new PointStruct(lastLocation.X, lastLocation.Y + 2)) 
                || currentplayer.SelectedPiece.Position.Equals(new PointStruct(lastLocation.X, lastLocation.Y - 2))))
            {
                Pawn pawn = (Pawn)currentplayer.SelectedPiece;
                pawn.SwitchCanBePassed();
            }

            // update list if needed
            currentplayer.updateList(Pieces);

            // if everything is done switch turn sides
            players[0].SwitchTurns();
            players[1].SwitchTurns();
        }
        // check if the game has ended
        if (isEnd())
        {
            // WAITING FOR PHIL !!!!
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
        var pieces = new List<Piece>(players[0].Pieces.Count() + players[1].Pieces.Count());

        // loop through the pieces of each player to add them in a bigger list
        foreach (var item in players[0].Pieces)
        {
            pieces.Add(item);
        }
        foreach (var item in players[1].Pieces)
        {
            pieces.Add(item);
        }

        return pieces;
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
                    if (GAMESTATUS == GameStatus.BLACK_WIN)
                    {
                        wnd.Black_Won();
                    }
                    else if (GAMESTATUS == GameStatus.WHITE_WIN)
                    {
                        wnd.White_Won();
                    }                    // close window / show victory screen 
                    // MainWindow.Won();
                    // Show a messagebox to visualize victory
                    //MessageBox.Show(GAMESTATUS.ToString());
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
