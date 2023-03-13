using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class PlayerTurn
{
    protected List<Pieces> pieces;
    protected TextBlock[,] textBlocks;
    protected Player[] player;
    Pieces movedPiece;
    GameStatus status;

    public PlayerTurn(Player[] player, TextBlock[,] textBlocks, List<Pieces> pieces)
    {
        this.player = player;
        this.textBlocks = textBlocks;
        this.pieces = pieces;
    }

    /*
     * 
     * 
     */

    public void Turns()
    {
        status = GameStatus.ACTIVE;
        // change Playerturns
        byte playerturns = 1;

        while (playerturns != byte.MaxValue)
        {
            // check for endgame
            isEnd();

            bool turn = (playerturns % 2 != 0) ? player[0].IsWhite : player[1].IsWhite;
            if (turn)
            {
                // moving logic for the players turn
                //if()
                //{
                //    return;
                //}

                checkLists(pieces);
            }
            // increase turn counter
            playerturns++;
        }
    }

    void checkLists(List<Pieces> pieces)
    {
        List<Pieces> tempPieces = pieces;

        // compare the temporary list and update it to the current stand
        foreach (var piece in tempPieces)
        {
            //if ()
            //{
            //    tempPieces = pieces;
            //    break;
            //}
        }
    }

    /// <summary>
    /// checking for end state
    /// </summary>
    /// <returns></returns>
    public bool isEnd()
    {
        return this.status != GameStatus.ACTIVE;
    }

}
