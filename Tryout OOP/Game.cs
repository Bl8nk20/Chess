using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Tryout_OOP;

internal class Game
{
    #region Properties
    GameStatus GAMESTATUS;
    GameMode GAMEMODE;
    ushort currentTurn = 1;
    Player Player1;
    Player Player2;
    #endregion

    #region Constructor
    public Game()
    {
        List<TextBlock> TextBlockList = new List<TextBlock>(64);
        this.Player1 = new Player(TextBlockList, true); // WHite Player
        this.Player2 = new Player(TextBlockList); // Black Player
    }
    #endregion

    #region Methods
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
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    internal List<Piece> InitialPieces()
    {
        // Looping for each player list to one list with both contents
        var pieces = new List<Piece>(Player1.Pieces.Count() + Player2.Pieces.Count());
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

    #endregion
}
