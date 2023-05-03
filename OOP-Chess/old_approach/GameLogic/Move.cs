namespace OOP_Chess;

public class Move
{
    // user / player
    private Player player;
    // start position
    private Spot start;
    public Spot Start
    {
        get { return start; }
        set { start = value; }
    }
    // end position
    private Spot end;
    public Spot End
    {
        get { return end; }
        set { end = value; }
    }
    // moved piece
    private Pieces pieceMoved;
    public Pieces PieceMoved
    {
        get { return pieceMoved; }
        set { pieceMoved = value; }
    }
    // killed / captured piece
    private Pieces pieceKilled;
    public Pieces PieceKilled
    {
        get { return pieceKilled; }
        set { pieceKilled = value; }
    }
    // castling move from king
    private bool isCastlingMove = false;
    public bool IsCastlingMove
    {
        get { return isCastlingMove; }
        set { isCastlingMove = value; }
    }
    /// <summary>
    /// constructor of the move for logging
    /// </summary>
    /// <param name="player"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    public Move(Player player, Spot start, Spot end)
    {
        this.player = player;
        this.start = start;
        this.end = end;
        this.pieceMoved = start.Piece;
    }

}
