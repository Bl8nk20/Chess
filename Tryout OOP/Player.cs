using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryout_OOP;

public class Player
{
    private bool isWhite;
    public bool IsWhite
    {
        get { return isWhite; }
    }

    public Player(bool isWhite = false)
    {
        this.isWhite = isWhite;
    }
}
