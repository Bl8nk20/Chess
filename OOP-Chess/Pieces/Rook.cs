using System.Windows.Media.Imaging;

namespace OOP_Chess;

public class Rook : Pieces
{

    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Rook(byte x, byte y, bool isWhite) 
        : base(x, y, isWhite, isWhite ? '\u2656' : '\u265C')
    {
        // empty Constructor cause nothing is needed :D
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool CanMove(byte xTarget, byte yTarget)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour
        
        return xTarget == x || yTarget == y;
    }
}