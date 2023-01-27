using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Chess.Interfaces;

namespace OOP_Chess.Pieces;

internal class Rook : IPieces
{
    // Locations of the pieces
    private byte xCurrent; // cols 0...7
    private byte yCurrent; // rows 0...7, bottom is row 0
    protected byte XCurrent
    {
        get {return xCurrent; }
        set {xCurrent = value; }
    } 

    protected byte YCurrent
    {
        get {return yCurrent; }
        set {yCurrent = value; }
    }

    public Rook(byte YCurrent, byte XCurrent)
    {
        this.YCurrent = YCurrent;
        this.XCurrent = XCurrent;
        // (turn % 2 != 0) ? PlayersTurn.W : PlayersTurn.B;

    }

    /// assumption: xTarget and yTarget between 0 and 7
    /// assumption: Target != Current
    /// assumption: nobody is in the way
    /// Return: Is move possible
    public bool IsValidMove(byte xTarget, byte yTarget)
    {
        return xTarget == xCurrent || yTarget == yCurrent;
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

