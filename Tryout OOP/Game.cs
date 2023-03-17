using System.Collections.Generic;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    GameStatus GAMESTATUS;
    GameMode GAMEMODE;
    ushort currentTurn = 1;
    Player Player1;
    Player Player2;

    public Game()
    {
        Player Player1 = new Player(true);
        Player Player2 = new Player();
    }

    /// <summary>
    /// 
    /// </summary>
    public void playerMovement()
    {
        Player currentPlayer = (currentTurn % 2!= 0) ? Player1 : Player2;
        //
        CheckKingKill(currentPlayer);

        // check if the Gamestate has changed
        isEnd();

        // visuals for debug
        // TextBlockPlayer.Text = (PlayerTurn.Counter % 2) != 0 ? Player1.IsWhite.ToString() : Player2.IsWhite.ToString();
        // TextBlockTurns.Text = PlayerTurn.Counter.ToString();

        if (Player1.IsTurn)
        {
            // movedPiece = (PlayerTurn.Counter % 2) != 0 ? Player1.SelectedPiece : Player2.SelectedPiece;

            if (!Player1.CanMove(movedPiece))
            {
                return;
            }
        }
        else if (Player2.IsTurn)
        {
            if (Player2.CanMove(movedPiece))
            {
                return;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void CheckKingKill(Player currentPlayer)
    {
        foreach (var piece in currentPlayer.Pieces)
        {
            if (piece.IsKilled && piece is King)
            {
                GAMESTATUS = currentPlayer.IsWhite ? GAMESTATUS = GameStatus.BLACK_WIN : GameStatus.WHITE_WIN;
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
}
