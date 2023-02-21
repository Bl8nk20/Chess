using System;
using System.IO;

namespace Tryout_OOP;

public class Pawn : Pieces
{
    private bool hasMoved = false;
    public bool HasMoved
    {
        get { return hasMoved; }
        set { hasMoved = value; }
    }
    /// <summary>
    /// Constructor for the Roock Chesspiece
    /// </summary>
    /// <param name="isWhite"></param>
    public Pawn(PointStruct Point, bool isWhite, bool isKilled)
        : base(Point, isWhite, isKilled, isWhite ? '\u2659' : '\u265F')
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
    public override bool CanMove(PointStruct TargetPoint)
    {
        // we can't move the piece to a spot that has
        // a piece of the same colour
        //if (!this.hasMoved)
        //{
        //    return (TargetPoint.Y == this.Position.Y + 2  && this.Position.X == TargetPoint.X) 
        //        || (TargetPoint.Y == this.Position.Y + 1 && this.Position.X == TargetPoint.X);
        //}

        int x = Math.Abs(this.Point.X - TargetPoint.X);
        int y = Math.Abs(this.Point.Y - TargetPoint.Y);
        if(!this.isWhite)
        {
            return TargetPoint.Y == this.Position.Y - 1 && this.Position.X == TargetPoint.X;
        }
        // white Pawn movement
        if (hasMoved)
        {
            return TargetPoint.Y == this.Position.Y + 1 && this.Position.X == TargetPoint.X;
        }
        return TargetPoint.Y == this.Position.Y + 2 && this.Position.X == TargetPoint.X;

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
    //public override bool CanMove(Board board, Spot start, Spot end)
    //{
    //    // we can't move the piece to a spot that has
    //    // a piece of the same colour
    //    if (end.Piece.IsWhite == this.IsWhite)
    //    {
    //        return false;
    //    }
    //    if (hasMoved)
    //    {
    //        return false;
    //    }
    //    // update movement
    //    // write movement method further!
    //    // movement
    //    hasMoved = true; // set movement afterwards to true
    //    return true;
    //}

    /// <summary>
    /// Method to check if en passant is executeable
    /// if so do it
    /// if pawn is above/ has crossed the middle line 
    /// AND a pawn has moved from his init-position
    /// -> pawn can then throw like 
    /// </summary>
    /// <returns></returns>
    //public bool EnPassant(Board board, Spot start, Spot end)
    //{
    //    // if pawn is above/ has crossed the middle line 
    //    // AND a pawn has moved from his init-position
    //    // -> pawn can then throw like the other pawn dont stand near him
    //    //if(end.Piece. != this.IsWhite) // now only thing left is the checking if left or right is another pawn
    //    //{

    //    //}


    //    return false;
    //}

    /// <summary>
    /// Method to check for promotion availability
    /// if so execute it
    /// </summary>
    /// <returns></returns>
    public bool Promotion()
    {
        // Pawn needs to be at the end of the board
        // Popup ? to which piece the pawn should be promoted
        // execute promotion logic -> pawn no longer behaves like pawn

        return false;
    }
}
