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
    internal ushort playerturns = 1;
    public Player Player1
    {
        get;
        internal set;
    }
    public Player Player2
    {
        get;
        internal set;
    }

    GameStatus status;

    public PlayerTurn(TextBlock[,] textBlocks, List<Pieces> pieces)
    {
        this.textBlocks = textBlocks;
        this.pieces = pieces;
        Player1 = new Player(true);
        Player2 = new Player();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Player GetCurrentPlayer()
    {
        if (Player2.IsTurn)
            return Player2;
        else
            return Player1;
    }

    /// <summary>
    /// 
    /// </summary>
    internal void ChangePlayer()
    {
        if (Player1.IsTurn)
        {
            Player1.IsTurn = false;
            Player2.IsTurn = true;
        }
        else
        {
            Player1.IsTurn = true;
            Player2.IsTurn = false;
        }
        // increase the playercount
        playerturns++;
    }

    /// <summary>
    /// 
    /// </summary>
    void CheckKingKill()
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