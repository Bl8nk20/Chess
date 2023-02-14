namespace OOP_Chess;

public class HumanPlayer : Player
{
    /// <summary>
    /// Constructor for the Human Player Class -> Human PLayer Movement/ Verification
    /// </summary>
    /// <param name="whiteSide"></param>
    public HumanPlayer(bool whiteSide)
    {
        this.IsWhiteSide = whiteSide;
        this.IsHumanPlayer = true;
    }
}