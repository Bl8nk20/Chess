using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class PlayerTurn
{
    protected List<Pieces> pieces;
    protected TextBlock[,] textBlocks;
    GameStatus status;

    public PlayerTurn(TextBlock[,] textBlocks, List<Pieces> pieces)
    {
        this.textBlocks = textBlocks;
        this.pieces = pieces;
    }



    /// <summary>
    /// 
    /// </summary>
    void CheckkingKill()
    {
        foreach (var piece in pieces)
        {
            if (piece.IsKilled && piece is King && !piece.IsWhite)
            {
                status = GameStatus.WHITE_WIN;
            }
            else if (piece.IsKilled && piece.IsWhite && piece is King)
            {
                status = GameStatus.BLACK_WIN;
            }
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