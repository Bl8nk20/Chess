namespace OOP_Chess;

/// <summary>
/// an abstract class to set a blueprint for each chesspiece
/// </summary>
public abstract class Pieces
{
    /// <summary>
    /// bool value to check later if it is captured
    /// </summary>
    private bool isKilled = false;
    public bool IsKilled
    {
        get { return isKilled; }
        set { isKilled = value; }
    }

    /// <summary>
    /// bool value to check if the piece belongs to Player1 (white) or Player2 (black)
    /// </summary>
    private bool isWhite = false;
    public bool IsWhite
    {
        get { return isWhite; }
        set { isWhite = value; }
    }

    /// <summary>
    /// Constructor for the Pieces
    /// </summary>
    /// <param name="isWhite"></param>
    public Pieces(bool isWhite)
    {
        this.IsWhite = isWhite;
    }

    /// <summary>
    /// a method to define each move, each chesspiece could do
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start">starting spot</param>
    /// <param name="end">targeted spot</param>
    /// <returns></returns>
    public abstract bool CanMove(Board board, Spot start, Spot end);
}
