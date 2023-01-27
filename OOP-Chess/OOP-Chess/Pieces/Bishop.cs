using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Chess.Interfaces;

namespace OOP_Chess.Pieces;

internal class Bishop : IPieces
{
    // Locations of the pieces
    private byte xCurrent; // cols 0...7
    private byte yCurrent; // rows 0...7, bottom is row 0
    public byte XCurrent
    {
        get; set;
    }

    public byte YCurrent
    {
        get; set;
    }

    /// assumption: xTarget and yTarget between 0 and 7
    /// assumption: Target != Current
    /// assumption: nobody is in the way
    /// Return: Is move possible
    public bool IsValidMove(byte xTarget, byte yTarget)
    {

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
