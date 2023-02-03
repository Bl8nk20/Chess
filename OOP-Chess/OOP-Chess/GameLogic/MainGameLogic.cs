using System.Collections.Generic;

namespace OOP_Chess;

public class Game
{
    // array for the players
    private Player[] players;

    // initialize the board
    private Board board;
    // get current turn
    private Player currentTurn;
    // enum for gamestatus checking
    private GameStatus status;
    public GameStatus Status
    {
        get { return status; }
        set { status = value; }
    }
    // list for logging
    private List<Move> movesPlayed;

    /// <summary>
    /// a method to initialize the the game
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    private void initialize(Player p1, Player p2)
    {
        players[0] = p1;
        players[1] = p2;

        // reset the board
        board.resetBoard();

        // set turns
        if (p1.IsWhiteSide)
        {
            this.currentTurn = p1;
        }
        else
        {
            this.currentTurn = p2;
        }
        // clear the previous list
        movesPlayed.Clear();
    }

    // checking for end state
    public bool isEnd()
    {
        return this.Status != GameStatus.ACTIVE;
    }

    // movement of the player
    public bool playerMove(Player player, int startX, int startY, int endX, int endY)
    {
        Spot startBox = board.getBox(startX, startY);
        Spot endBox = board.getBox(startY, endY);
        Move move = new Move(player, startBox, endBox);
        return this.makeMove(move, player);
    }

    // check if the move is valid and can execute
    private bool makeMove(Move move, Player player)
    {
        Pieces sourcePiece = move.Start.Piece;
        // if the player chooses an empy field
        if (sourcePiece == null)
        {
            return false;
        }

        // valid player
        if (player != currentTurn)
        {
            return false;
        }

        // player chooses a black piece
        if (sourcePiece.IsWhite != player.IsWhiteSide)
        {
            return false;
        }

        // valid move?
        if (!sourcePiece.CanMove(board, move.Start, move.End))
        {
            return false;
        }

        // kill?
        Pieces destPiece = move.Start.Piece;
        if (destPiece != null)
        {
            destPiece.IsKilled = true;
            move.PieceKilled = destPiece;
        }

        // castling?
        if (sourcePiece != null && sourcePiece is King && ((King)sourcePiece).isCastlingMove(move.Start, move.End))
        {
            move.IsCastlingMove = true;
        }

        // store the move
        movesPlayed.Add(move);

        // move piece from the stat box to end box
        move.End.Piece = move.Start.Piece;
        move.Start.Piece = null;

        // end state checking
        if (destPiece != null && destPiece is King)
        {
            if (player.IsWhiteSide)
            {
                this.Status = GameStatus.WHITE_WIN;
            }
            else
            {
                this.Status = GameStatus.BLACK_WIN;
            }
        }

        // set the current turn to the other player
        if (this.currentTurn == players[0])
        {
            this.currentTurn = players[1];
        }
        else
        {
            this.currentTurn = players[0];
        }

        return true;
    }
}
