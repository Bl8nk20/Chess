using System;
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

    public Game(Player Player1, Player Player2, TextBlock[,] textBlocks)
    {
        this.Player1 = Player1;
        this.Player2 = Player2;
        this.PlayerTurn = new PlayerTurn(textBlocks, pieces);
    }

    public void Playing()
    {
        playerMovement();

    }

    /// <summary>
    /// 
    /// </summary>
    void playerMovement()
    {
        if (Player1.IsTurn)
        {
            if (!Player1.CanMove(movedPiece))
            {
                return;
            }
            // swap players turn
            PlayerTurn.ChangePlayer();
        }
        else if (Player2.IsTurn)
        {
            if (!Player2.CanMove(movedPiece))
            {
                return;
            }
            // swap players turn
            PlayerTurn.ChangePlayer();
        }
    }

}
