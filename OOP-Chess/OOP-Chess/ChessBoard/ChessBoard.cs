using System;

namespace OOP_Chess;

public class Board
{
    /// <summary>
    /// define a 2d Array
    /// </summary>
    Spot[,] boxes;

    /// <summary>
    /// constructor to reset the board if called
    /// </summary>
    public Board()
    {
        this.resetBoard();
    }

    /// <summary>
    /// generate the board
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Spot getBox(int x, int y)
    {

        if (x < 0 || x > 7 || y < 0 || y > 7)
        {
            throw new Exception("Index out of bound");
        }

        return boxes[x, y];
    }

    /// <summary>
    /// reset the board and hardcoded piece setting
    /// </summary>
    public void resetBoard()
    {
        // initialize white pieces
        boxes[0, 0] = new Spot(0, 0, new Rook(true));
        boxes[0, 1] = new Spot(0, 1, new Knight(true));
        boxes[0, 2] = new Spot(0, 2, new Bishop(true));
        boxes[0, 3] = new Spot(0, 0, new Queen(true));
        boxes[0, 4] = new Spot(0, 1, new King(true));
        boxes[0, 5] = new Spot(0, 2, new Bishop(true));
        boxes[0, 6] = new Spot(0, 1, new Knight(true));
        boxes[0, 7] = new Spot(0, 2, new Rook(true));
        boxes[1, 0] = new Spot(1, 0, new Pawn(true));
        boxes[1, 1] = new Spot(1, 1, new Pawn(true));
        boxes[1, 2] = new Spot(1, 0, new Pawn(true));
        boxes[1, 3] = new Spot(1, 1, new Pawn(true));
        boxes[1, 4] = new Spot(1, 0, new Pawn(true));
        boxes[1, 5] = new Spot(1, 1, new Pawn(true));
        boxes[1, 6] = new Spot(1, 0, new Pawn(true));
        boxes[1, 7] = new Spot(1, 1, new Pawn(true));

        // initialize black pieces
        boxes[7, 0] = new Spot(0, 0, new Rook(false));
        boxes[7, 1] = new Spot(0, 1, new Knight(false));
        boxes[7, 2] = new Spot(0, 2, new Bishop(false));
        boxes[7, 3] = new Spot(0, 0, new Queen(false));
        boxes[7, 4] = new Spot(0, 1, new King(false));
        boxes[7, 5] = new Spot(0, 2, new Bishop(false));
        boxes[7, 6] = new Spot(0, 1, new Knight(false));
        boxes[7, 7] = new Spot(0, 2, new Rook(false));
        boxes[6, 0] = new Spot(1, 0, new Pawn(false));
        boxes[6, 1] = new Spot(1, 1, new Pawn(false));
        boxes[6, 2] = new Spot(1, 0, new Pawn(false));
        boxes[6, 3] = new Spot(1, 1, new Pawn(false));
        boxes[6, 4] = new Spot(1, 0, new Pawn(false));
        boxes[6, 5] = new Spot(1, 1, new Pawn(false));
        boxes[6, 6] = new Spot(1, 0, new Pawn(false));
        boxes[6, 7] = new Spot(1, 1, new Pawn(false));

        // initialize remaining boxes without any piece
        for (byte i = 2; i < 6; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                boxes[i, j] = new Spot(i, j, null);
            }
        }
    }
}
