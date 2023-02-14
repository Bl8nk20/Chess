namespace OOP_Chess;

/// <summary>
/// a abstract class to define a player class as an interface for the user or computer
/// </summary>
public abstract class Player
{
    /// <summary>
    /// bool value to check if the player is the white side or black side
    /// </summary>
    private bool isWhiteSide;
    public bool IsWhiteSide
    {
        get { return isWhiteSide; }
        set { isWhiteSide = value; }
    }

    /// <summary>
    /// a bool value to check if the user is a human or the computer enemy
    /// </summary>
    private bool isHumanPlyer;
    public bool IsHumanPlayer
    {
        get { return isHumanPlyer; }
        set { isHumanPlyer = value; }
    }
}
