using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tryout_OOP;

internal class Coloring_Movement
{
    TextBlock[,] textBlocks { get; set; }
    List<Piece> pieces { get; set; }
    Piece movedPiece { get; set; }

    public Coloring_Movement(TextBlock[,] textBlocks, List<Piece> pieces, Piece movedPiece)
    {
        this.textBlocks = textBlocks;
        this.pieces = pieces;
        this.movedPiece = movedPiece;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Start()
    {
        // checking if player clicked an empty textblock or not
        if (movedPiece == null)
        {
            return;
        }

        for(int i = 0; i < textBlocks.GetLength(0); i++)
        {
            for(int j = 0; j < textBlocks.GetLength(1); j++)
            {
                Coloring(i,j);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void Coloring(int i, int j)
    {
        // check if the piece can move legally
        if (movedPiece.CanMove(new PointStruct(i, j), pieces))
        {
            // helping the Move Decision
            // by coloring the Background in Yellow
            textBlocks[i, j].Background = Brushes.LightGoldenrodYellow;
        }

        // coloring the enemys / opponent pieces
        foreach (var piece in pieces)
        {
            // if x and y ==
            // AND enemy color
            // AND Piece can move to that
            //  then:
            // color background
            if (piece.Position.X == i
                && piece.Position.Y == j
                && movedPiece.IsWhite != piece.IsWhite
                && movedPiece.CanMove(new PointStruct(i, j), pieces))
            {
                textBlocks[i, j].Background = Brushes.IndianRed;
            }
            
            // checking the x and y is eqal
            // AND own color
            // AND piece can move to that
            // then:
            // remove the colored background
            if (piece.Position.X == i
                && piece.Position.Y == j
                && movedPiece.IsWhite == piece.IsWhite
                && movedPiece.CanMove(new PointStruct(i, j), pieces))
            {
                textBlocks[i, j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
            }
        }
    }
}
