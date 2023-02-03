namespace OOP_Chess;

public class Pawn : Pieces
{
    /// <summary>
    /// Constructor for the Pawn Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Pawn(bool isWhite) : base(isWhite)
    {

    }

    /// <summary>
    /// overridden movement method to check the move
    /// pawn movement: if first time moving: pawn can step forward 2 spots
    ///                if !first time moving: pawn can step forward 1 spot
    ///                if enemy diagonal: can throw diagonaly
    ///                if enemy has moved 2 steps and is standing on the same level as pawn: en passant!
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

        // update movement
        // write movement method further!
        return true;
    }


    public bool EnPassant()
    {
        return true;
    }
}
