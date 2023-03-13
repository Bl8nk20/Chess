using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryout_OOP;

public struct PointStruct
{
    public PointStruct(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

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
}
