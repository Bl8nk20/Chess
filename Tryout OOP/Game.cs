using System.Collections.Generic;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    GameStatus status;
    GameMode mode;
    Player Player1;
    Player Player2;
    Piece movedPiece;
    List<Piece> pieces;
    PlayerTurn PlayerTurn;
    TextBlock[,] textBlocks;
    TextBox TextBlockTurns, TextBlockPlayer;


    public Game(Player Player1, Player Player2, TextBlock[,] textBlocks, TextBox textboxturns, TextBox textboxPlayer)
    {
        this.Player1 = Player1;
        this.Player2 = Player2;
        this.textBlocks = textBlocks;
        this.TextBlockTurns = textboxturns;
        this.TextBlockPlayer = textboxPlayer;

        // initialize pieces list
        this.pieces = new List<Piece>();

        this.PlayerTurn = new PlayerTurn(textBlocks, pieces);
    }

    /// <summary>
    /// 
    /// </summary>
    public void playerMovement()
    { 
        //
        PlayerTurn.CheckKingKill();
        // check if the Gamestate has changed
        PlayerTurn.isEnd();

        movedPiece = (PlayerTurn.Counter % 2) == 0 ? Player1.SelectedPiece : Player2.SelectedPiece;

        if (Player1.IsTurn)
        {
            if (!Player1.CanMove(movedPiece))
            {
                return;
            }
            movedPiece = Player1.SelectedPiece;
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
            movedPiece = Player2.SelectedPiece;
            // swap players turn
            Player2.SwitchTurns();
            Player1.SwitchTurns();
        }
    }
}
