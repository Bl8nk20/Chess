using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tryout_OOP;

internal class Logic
{
    protected List<Pieces> pieces;
    protected TextBlock[,] textBlocks;
    private Player player1;
    private Player player2;

    public Player Player1
    {
        set { player1 = value; }
        get {return player1; }
    }
    public Player Player2
    {
        set { player2 = value; }
        get { return player2; }
    }

    Pieces movedPiece;
    // enum for gamestatus checking
    private GameStatus status;
    public GameStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public Logic(List<Pieces> pieces, TextBlock[,] textBlocks, Pieces movedPiece)
    {
        this.pieces = pieces;
        this.textBlocks = textBlocks;
        this.movedPiece = movedPiece;
        this.Player1 = new Player(true);
        this.Player2 = new Player();
    }

    internal Player GetCurrentPlayer()
    {
        if (Player2.IsTurn)
            return Player2;
        else
            return Player1;
    }

    internal void ChangePlayer()
    {
        if (Player1.IsTurn)
        {
            Player1.IsTurn = false;
            Player2.IsTurn = true;
        }
        else
        {
            Player1.IsTurn = true;
            Player2.IsTurn = false;
        }
    }



    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    internal List<Pieces> InitialPieces()
    {
        // Looping for each player list to one list with both contents
        var pieces = new List<Pieces>(Player1.Pieces.Count() + Player2.Pieces.Count());
        foreach(var item in Player1.Pieces)
        {
            pieces.Add(item);
        }
        foreach(var item in Player2.Pieces)
        {
            pieces.Add(item);
        }

        return pieces;
    }

    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the List, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    internal Pieces searchPiece(PointStruct p)
    {
        // Find Piece to move
        foreach(var piece in pieces)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (piece.Position.X == p.X && piece.Position.Y == p.Y)
            {
                movedPiece = piece;
            }
        }
        return movedPiece;
    }

    /// <summary>
    /// a method to validate if certain moves are valid
    /// e.g. En passant or Castling or Promoting
    /// </summary>
    internal void specialMoves()
    {
        Capture capture = new Capture();

        foreach (var piece in pieces)
        {
            // En Passant:
            // check if movedPiece is from type Pawn
            // check if on the left or right is another (enemy) pawn
            // check if he has moved two forward
            // throw diagonally
            if (movedPiece is Pawn && piece.Position.Y == movedPiece.Position.Y)
            {

            }

            // Castling
            // check if movedPiece is from type King
            // check if king and one of the Rooks haven´t been moved yet
            // check if the way is free (no bishop or knight or other piece is on same line)
            // move king two steps in rooks direction -> place rook on the left or right nearby
            // set king and rook to moved
            if(movedPiece is King)
            {

            }

            // Promotion
            // check if pawn has reached end of board
            // ask player to which piece the pawn should be promoted
            // remove pawn -> replace it with players choice
            if (movedPiece is Pawn && movedPiece.Position.X == 7)
            {
                // piece needed to replace either with the user input or a specific piece
                movedPiece.IsKilled = true;
                capture.updateList(pieces);
                //pieces.Add(new ...(movedPiece.Position));
            }
        }
    }
}
