namespace OOP_Chess;

public class Spot
{
    /// <summary>
    /// abstract Piece Class
    /// </summary>
    private Pieces piece;
    public Pieces Piece
    {
        get { return piece; }
        set { piece = value; }
    }
    /// <summary>
    /// X Coordinate to find/ analyse which spot it is later on
    /// </summary>
    private byte x;
    public byte X
    {
        get { return x; }
        set { x = value; }
    }

    /// <summary>
    /// Y Coordinate to find/ analyse which spot it is later on
    /// </summary>
    private byte y;
    public byte Y
    {
        get { return y; }
        set { y = value; }
    }

    /// <summary>
    /// Constructor for the single Fields for the Chessboard
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="piece"></param>
    public Spot(byte x, byte y, Pieces piece)
    {
        Piece = piece;
        X = x;
        Y = y;
    }

}

