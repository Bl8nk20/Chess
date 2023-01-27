using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Chess.Interfaces;


namespace OOP_Chess.Pieces;

internal class Pawn : IPieces
{
    // Locations of the pieces
    private byte xCurrent; // cols 0...7
    private byte yCurrent; // rows 0...7, bottom is row 0
    protected byte XCurrent
    {
        get; set;
    }

    protected byte YCurrent
    {
        get; set;
    }


    public void FigureColor(int PlayerTurn)
    {

    }

    /// assumption: xTarget and yTarget between 0 and 7
    /// assumption: Target != Current
    /// assumption: nobody is in the way
    /// Return: Is move possible
    public bool IsValidMove(byte xTarget, byte yTarget)
    {
        return true;
    }

    //
    public void Move(byte xTarget, byte yTarget)
    {
        if(!IsValidMove(xTarget, yTarget))
        {
            throw new Exception("No Valid Move!");
        }
        XCurrent = xTarget;
        YCurrent = yTarget;
    }

    //
    public void Remove()
    {

    }
}