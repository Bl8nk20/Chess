using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Chess.Interfaces;


namespace OOP_Chess.Pieces;

internal class Queen : IPieces
{
    private enum Colors
    {
        B,
        W
    }

    
    // Locations of the pieces
    private int xCurrent; // cols 0...7
    private int yCurrent; // rows 0...7, bottom is row 0
    public int XCurrent
    {
        get; set;
    }
    public int YCurrent
    {
        get; set;
    }

    public bool IsValidMove()
    {
        return true;
    }

    public bool Move(int xTarget, int yTarget)
    {
        return true;
    }

    public void Remove()
    {

    }

}
