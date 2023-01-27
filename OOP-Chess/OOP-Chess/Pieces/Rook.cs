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
    public byte XCurrent
    {
        get; set;
    }
    public byte YCurrent
    {
        get; set;
    }

    public Rook()
    {
        this.xCurrent = 0;
        this.yCurrent = 0;

    }

    
    // assumption: xTarget and yTarget between 0 and 7
    // assumption: Target != Current
    // Return: Is move possible
    public bool IsValidMove(byte xTarget, byte yTarget)
    {
        if(xTarget == xCurrent || yTarget == yCurrent)
        {
            return true;
        }
        return true;
    }

    public void Move(byte xTarget, byte yTarget)
    {

    }

    public void Remove()
    {

    }

}

