using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace OOP_Chess;

internal class Coloring_Movement
{
    #region Properties
    TextBlock[,] textBlocks { get; set; }
    List<Piece> pieces { get; set; }
    Piece movedPiece { get; set; }
    #endregion

    #region Constructor
    public Coloring_Movement(TextBlock[,] textBlocks, List<Piece> pieces, Piece movedPiece)
    {
        this.textBlocks = textBlocks;
        this.pieces = pieces;
        this.movedPiece = movedPiece;
    }
#endregion

    #region Methods
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
        if (movedPiece.CanMove(new PointStruct(i, j), pieces, movedPiece))
        {
            // helping the Move Decision
            // by coloring the Background in Yellow
            textBlocks[i, j].Background = Brushes.LightGoldenrodYellow;
        }

        // coloring the enemys / opponent pieces
        foreach (var piece in pieces)
        {
            // colors the textblocks on which a piece an move and when there is a enemy piece on it
            if (checkConditionEnemyInWay(piece, i, j))
            {
                textBlocks[i, j].Background = Brushes.IndianRed;
            }
            
            // removes the coloring if the piece cant move to htat point
            if (checkConditionRemoveColor(piece, i, j))
            {
                textBlocks[i, j].Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
            }
        }
    }

    #region Check Conditions
    /// <summary>
    /// A method to check if all conditions to simplify the methods : 
    /// checking the x and y is eqal
    /// AND own color
    /// AND piece can move to that
    /// </summary>
    /// <param name="piece">current piece from List of pieces</param>
    /// <param name="i">index i</param>
    /// <param name="j">index j</param>
    /// <returns></returns>
    bool checkConditionRemoveColor(Piece piece, int i, int j)
    {
        return piece.Position.X == i && piece.Position.Y == j && movedPiece.IsWhite == piece.IsWhite && movedPiece.CanMove(new PointStruct(i, j), pieces, movedPiece);
    }

    /// <summary>
    /// A method to check if all conditions to simplify the methods : 
    /// if x and y ==
    /// AND enemy color
    /// AND Piece can move to that
    /// </summary>
    /// <param name="piece"></param>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    bool checkConditionEnemyInWay(Piece piece, int i, int j)
    {
        return piece.Position.X == i && piece.Position.Y == j && movedPiece.IsWhite != piece.IsWhite && movedPiece.CanMove(new PointStruct(i, j), pieces, movedPiece);
    }
    #endregion

    #endregion
}
