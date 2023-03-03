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
    protected Player[] player;
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
    }

    /// <summary>
    /// Logic for the game.
    /// e.g players turn 
    /// </summary>
    public void Game()
    {
        Player[] players = new Player[2];
        players[0] = new Player(true);
        players[1] = new Player(false);

        // change Playerturns
        byte playerturns = 1;
        while (playerturns != byte.MaxValue)
        {
            bool turn = (playerturns % 2 != 0) ? players[0].IsWhite : players[1].IsWhite;
            if (turn)
            {
                // moving logic for the players turn
                //if()
                //{
                //    return;
                //}

                checkLists(pieces);
            }
            // increase turn counter
            playerturns++;

            Status = GameStatus.WHITE_WIN;

            // check for endgame
            isEnd();
        }
    }

    void checkLists(List<Pieces> pieces)
    {
        List<Pieces> tempPieces = pieces;

        // compare the temporary list and update it to the current stand
        foreach (var piece in tempPieces)
        {
            //if ()
            //{
            //    tempPieces = pieces;
            //    break;
            //}
        }
    }

    /// <summary>
    /// checking for end state
    /// </summary>
    /// <returns></returns>
    public bool isEnd()
    {
        return this.Status != GameStatus.ACTIVE;
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    internal List<Pieces> InitialPieces()
    {
        List<Pieces> pieces = new List<Pieces>();

        // add white pieces
        // add white Pawns
        for (byte i = 0; i < textBlocks.GetLength(0); i++)
        {
            pieces.Add(new Pawn(new PointStruct(i, 1), true, false));

        }
        // add white Knights
        pieces.Add(new Knight(new PointStruct(1, 0), true, false));
        pieces.Add(new Knight(new PointStruct(6, 0), true, false));

        // add white Bishops
        pieces.Add(new Bishop(new PointStruct(2, 0), true, false));
        pieces.Add(new Bishop(new PointStruct(5, 0), true, false));

        // add white Rooks
        pieces.Add(new Rook(new PointStruct(0, 0), true, false));
        pieces.Add(new Rook(new PointStruct(7, 0), true, false));

        // add white Queen
        pieces.Add(new Queen(new PointStruct(3, 0), true, false));

        // add White King
        pieces.Add(new King(new PointStruct(4, 0), true, false));

        // add black pieces
        // add Pawns
        for (byte i = 0; i < textBlocks.GetLength(0); i++)
        {
            pieces.Add(new Pawn(new PointStruct(i, 6), false, false));
        }

        // add Black Knights
        pieces.Add(new Knight(new PointStruct(1, 7), false, false));
        pieces.Add(new Knight(new PointStruct(6, 7), false, false));

        // add Black Bishops
        pieces.Add(new Bishop(new PointStruct(2, 7), false, false));
        pieces.Add(new Bishop(new PointStruct(5, 7), false, false));

        // add black Rooks
        pieces.Add(new Rook(new PointStruct(0, 7), false, false));
        pieces.Add(new Rook(new PointStruct(7, 7), false, false));

        // add Queens
        pieces.Add(new Queen(new PointStruct(3, 7), false, false));

        // add Kings
        pieces.Add(new King(new PointStruct(4, 7), false, false));

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
