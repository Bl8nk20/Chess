﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Chess;

public struct PointStruct
{
    #region Constructor for Struct
    public PointStruct(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    #endregion

    #region Properties
    int x; // columns 0...7
    public int X
    {
        get { return x; }
    }

    int y; // rows 0...7, bottom is 0
    public int Y
    {
        get { return y; }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Compares two Points on the GUI,
    /// true -> if points are identical,
    /// false -> points differ from eachother
    /// </summary>
    /// <param name="PointA">First Point to compare</param>
    /// <param name="PointB">Second Point to compare</param>
    /// <returns>a bool</returns>
    public static bool ComparePoints(PointStruct PointA, PointStruct PointB)
    {
        return PointA.X == PointB.X || PointA.Y == PointB.Y;
    }
    #endregion
}
