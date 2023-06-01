using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    #region Properties
    GameStatus GAMESTATUS;
    private Player[] players;
    //GameMode GAMEMODE;
    public List<Piece> Pieces;
    public Player currentPlayer;
    
    MainWindow wnd = (MainWindow)Application.Current.MainWindow;
    
    #endregion

    #region Constructor
    public Game()
    {
        players = new Player[]
        {
            new Player(true),
            new Player()
        };
        players[0].IsTurn = true;
        players[1].IsTurn = false;
        currentPlayer = setCurrentPlayer();
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
            players[0].SelectedPiece = players[0].SearchPiece(SelectedPoint);
            players[1].SelectedPiece = players[1].SearchPiece(SelectedPoint);
            wnd.TurnWhite();

        }
        else if (players[1].IsTurn)
        {
            players[1].SelectedPiece = players[1].SearchPiece(SelectedPoint);
            players[0].SelectedPiece = players[0].SearchPiece(SelectedPoint);
            wnd.TurnBlack();

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
        //foreach(Piece piece in Pieces)
        //{
        //    if(piece is Pawn && piece.IsWhite == currentplayer.IsWhite)
        //    {
        //        Pawn pawn = (Pawn)piece;
        //        pawn.CanBePassed = false;
        //    }
        //}

        // check if its the turn of the player and if he selected a piece
        if (!currentplayer.IsTurn
            || currentplayer.SelectedPiece == null)
        {
            return;
        }

        if (currentplayer.SelectedPiece is King && Math.Abs(TargetPoint.X - currentplayer.SelectedPiece.Position.X) > 1)
        {
            // ! Special Moves Like EnPassant, Castling, Promotion !
            currentplayer.Castling(currentplayer.SelectedPiece, TargetPoint);

            // if everything is done switch turn sides
            players[0].SwitchTurns();
            players[1].SwitchTurns();
        }

        // Promotion
        //if (currentplayer.SelectedPiece is Pawn)
        //{
        //    Promotion(currentplayer, Pieces);
        //}


        // check if piece has not moved
        // maybe need to use goto?
        if (currentplayer.SelectedPiece.Position.Equals(TargetPoint)
            || !currentplayer.SelectedPiece.CanMove(TargetPoint, Pieces, currentplayer.SelectedPiece))
        {
            return;
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

            // En passant possibility ? !!!!
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
                    }
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

    #region Promotion

    public void Promotion(Player currentplayer, List<Piece> Pieces)
    {

        /* 
         * First check if a pawn is at the end of the board
         * then open the promotion window
         */

        int y = (currentplayer.IsWhite) ? 7 : 0;
        Pawn pawn = (Pawn)currentplayer.SelectedPiece;

        if (pawn.Position.Equals(new PointStruct(currentplayer.SelectedPiece.Position.X, y)))
        {
            pawn.CanBePromoted = true;
        }
        // Checks if a pawn is at the end of the board
        if (pawn.CanBePromoted)
        {
            // Open Window for piece choosing
            wnd.promationContentW.Visibility = currentplayer.IsWhite ? Visibility.Visible : Visibility.Hidden;
            wnd.promationContentB.Visibility = !currentplayer.IsWhite ? Visibility.Visible : Visibility.Hidden;
            // replace selected piece accordingly to userinput

            switchingPieces(currentplayer, Pieces);
        }
    }

    /// <summary>
    /// Method to check a given string if that string 
    /// contains a message whether the pawn at the end 
    /// is now a queen or any other viable piece
    /// </summary>
    /// <param name="currentplayer"></param>
    /// <param name="Pieces"></param>
    /// <param name="Promotion"></param>
    void switchingPieces(Player currentplayer, List<Piece> Pieces)
    {
        string promoted = wnd.PromotedTo;

        if (promoted == "" || promoted == null)
        {
            return;
        }

        switch (promoted)
        {
            case "Queen":
                {
                    Pieces.Add(new Queen(currentplayer.SelectedPiece.Position, currentplayer.IsWhite));
                    currentplayer.SelectedPiece.IsKilled = true;
                    break;
                }
            case "Bishop":
                {
                    Pieces.Add(new Queen(currentplayer.SelectedPiece.Position, currentplayer.IsWhite));
                    currentplayer.SelectedPiece.IsKilled = true;
                    break;
                }
            case "Rook":
                {
                    Pieces.Add(new Queen(currentplayer.SelectedPiece.Position, currentplayer.IsWhite));
                    currentplayer.SelectedPiece.IsKilled = true;
                    break;
                }
            case "Knight":
                {
                    Pieces.Add(new Queen(currentplayer.SelectedPiece.Position, currentplayer.IsWhite));
                    currentplayer.SelectedPiece.IsKilled = true;
                    break;
                }
        }

        wnd.PromotedTo = "";
    }

    #endregion

    #endregion
}
