using System;
using System.Xml.Serialization;

namespace OOP_Chess;

public class Board
{
    /// <summary>
    /// define a 2d Array
    /// </summary>
    private Spot[,] boxes;
    public Spot[,] Boxes
    {
        set { boxes = value; }
        get { return boxes; }
    }

    /// <summary>
    /// constructor to reset the board if called
    /// </summary>
    public Board()
    {
        resetBoard();
    }

    /// <summary>
    /// get current position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public Spot getBox(byte x, byte y)
    {

        if (x < 0 || x > 7 || y < 0 || y > 7)
        {
            throw new Exception("Index out of bound");
        }

        return Boxes[x, y];
    }

    /// <summary>
    /// reset the board and hardcoded piece setting
    /// </summary>
    public void resetBoard()
    {
        try
        {
            //// initialize white pieces
            //Boxes[0, 0] = new Spot(0, 0, new Rook(true));
            ////Boxes[0, 1] = new Spot(0, 1, new Knight(true));
            ////Boxes[0, 2] = new Spot(0, 2, new Bishop(true));
            ////Boxes[0, 3] = new Spot(0, 3, new Queen(true));
            ////Boxes[0, 4] = new Spot(0, 4, new King(true));
            ////Boxes[0, 5] = new Spot(0, 5, new Bishop(true));
            ////Boxes[0, 6] = new Spot(0, 6, new Knight(true));
            //Boxes[0, 7] = new Spot(0, 7, new Rook(true));
            //Boxes[1, 0] = new Spot(1, 0, new Pawn(true));
            //Boxes[1, 1] = new Spot(1, 1, new Pawn(true));
            //Boxes[1, 2] = new Spot(1, 2, new Pawn(true));
            //Boxes[1, 3] = new Spot(1, 3, new Pawn(true));
            //Boxes[1, 4] = new Spot(1, 4, new Pawn(true));
            //Boxes[1, 5] = new Spot(1, 5, new Pawn(true));
            //Boxes[1, 6] = new Spot(1, 6, new Pawn(true));
            //Boxes[1, 7] = new Spot(1, 7, new Pawn(true));

            //// initialize black pieces
            //Boxes[7, 0] = new Spot(0, 0, new Rook(false));
            //Boxes[7, 1] = new Spot(0, 1, new Knight(false));
            //Boxes[7, 2] = new Spot(0, 2, new Bishop(false));
            //Boxes[7, 3] = new Spot(0, 3, new Queen(false));
            //Boxes[7, 4] = new Spot(0, 4, new King(false));
            //Boxes[7, 5] = new Spot(0, 5, new Bishop(false));
            //Boxes[7, 6] = new Spot(0, 6, new Knight(false));
            //Boxes[7, 7] = new Spot(0, 7, new Rook(false));
            //Boxes[6, 0] = new Spot(1, 0, new Pawn(false));
            //Boxes[6, 1] = new Spot(1, 1, new Pawn(false));
            //Boxes[6, 2] = new Spot(1, 2, new Pawn(false));
            //Boxes[6, 3] = new Spot(1, 3, new Pawn(false));
            //Boxes[6, 4] = new Spot(1, 4, new Pawn(false));
            //Boxes[6, 5] = new Spot(1, 5, new Pawn(false));
            //Boxes[6, 6] = new Spot(1, 6, new Pawn(false));
            //Boxes[6, 7] = new Spot(1, 7, new Pawn(false));

            // initialize remaining boxes without any piece
            for (byte i = 2; i < 6; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    Boxes[i, j] = new Spot(i, j, null);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
}
