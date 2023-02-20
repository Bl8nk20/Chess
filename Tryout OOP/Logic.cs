using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Tryout_OOP;

public class Logic
{
    protected List<Pieces> pieces;
    protected TextBlock[,] textBlocks;
    Pieces movedPiece;

    public Logic(List<Pieces> pieces, TextBlock[,] textBlocks, Pieces movedPiece)
    {
        this.pieces = pieces;
        this.textBlocks = textBlocks;
        this.movedPiece = movedPiece;
    }


    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    public List<Pieces> InitialPieces()
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
    /// in the Array, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    public Pieces searchPiece(PointStruct p)
    {
        // Find Piece to move
        for (byte i = 0; i < pieces.Count; i++)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (pieces[i].Position.X == p.X && pieces[i].Position.Y == p.Y)
            {
                movedPiece = pieces[i];
            }
        }
        return movedPiece;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="p"></param>
    void searchPossibleMoves(PointStruct p)
    {
        // method to search each tile if there is a
        // piece in the way of a piece which is clicked on
        // doing that using a for loop to search in the List of pieces, if 
    }
}
