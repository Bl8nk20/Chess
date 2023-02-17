using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryout_OOP;

public struct PointStruct
{
    public PointStruct(byte x, byte y)
    {
        this.x = x;
        this.y = y;
    }

    byte x; // columns 0...7
    public  byte X
    {
        get { return x; }
    }

    byte y; // rows 0...7, bottom is 0
    public byte Y
    {
        get { return y; }
    }
}
