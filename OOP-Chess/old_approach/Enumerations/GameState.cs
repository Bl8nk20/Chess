namespace OOP_Chess;

/// <summary>
/// enum to check the current gamestatus -> for eventtriggering
/// </summary>
public enum GameStatus
{
    ACTIVE,
    BLACK_WIN,
    WHITE_WIN,
    FORFEIT,
    STALEMATE,
    RESIGNATION
}
