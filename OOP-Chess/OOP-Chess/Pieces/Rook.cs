using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_Chess.Interfaces;

namespace OOP_Chess.Pieces;

internal class Rook : IPieces
{
    private enum Colors
    {
        B,
        W
    }

    private int[][]? _currentLoc;
    public int[][]  currentLoc
    { get; set; }

    public bool Moved
    {
        set;
        get;
    }

    public bool IsValidMove()
    {
        return true;
    }

    public void Move()
    {

    }
    public void Remove()
    {

    }
}

