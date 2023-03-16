﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    GameStatus status;
    GameMode mode;
    Player Player1;
    Player Player2;
    Pieces movedPiece;
    List<Pieces> pieces;
    PlayerTurn PlayerTurn;
    TextBlock[,] textBlocks;

    public Game(Player Player1, Player Player2, TextBlock[,] textBlocks)
    {
        this.Player1 = Player1;
        this.Player2 = Player2;
        this.textBlocks = textBlocks;

        // initialize pieces list
        this.pieces = new List<Pieces>();

        this.PlayerTurn = new PlayerTurn(textBlocks, pieces);
    }

    public void Playing()
    {
        Player1.IsTurn = true;
        AdditionalLogic AdditionalLogic = new AdditionalLogic(pieces, textBlocks, movedPiece);
        pieces = AdditionalLogic.InitialPieces();
        //
        Player1.IsTurn = true;
        playerMovement();
    }

    /// <summary>
    /// 
    /// </summary>
    void playerMovement()
    {
        movedPiece = Player1.SelectedPiece;
        if (Player1.IsTurn)
        {
            if (!Player1.CanMove(movedPiece))
            {
                return;
            }
            // swap players turn
            Player1.SwitchTurns();
            Player2.SwitchTurns();
        }
        else if (Player2.IsTurn)
        {
            if (!Player2.CanMove(movedPiece))
            {
                return;
            }
            // swap players turn
            Player2.SwitchTurns();
            Player1.SwitchTurns();
        }
    }

}
