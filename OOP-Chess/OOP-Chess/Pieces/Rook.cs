namespace OOP_Chess;

public class Rook : Pieces
{

    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Rook(bool isWhite) : base(isWhite)
    {
        // empty Constructor cause nothing is needed :D
    }

    /// <summary>
    /// overridden method for the movement of the Rook
    /// movement of Rook: directly horizontal or vertical
    /// </summary>
    /// <param name="board"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    public override bool CanMove(Board board, Spot start, Spot end)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour
        if (end.Piece.IsWhite == this.IsWhite)
        {
            return false;
        }

        return end.Y == start.Y || end.X == start.X;
    }
}