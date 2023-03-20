using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tryout_OOP;

internal class FEN_Startup
{
    #region Properties
    private string filename;
    public string Filename
    {
        internal set { filename = value; }
        get { return filename; }
    }
    private string Regex = @"(\d|[kqbnrpKQBNRP])";
    #endregion

    #region Constructor
    public FEN_Startup(string filename)
    {
        this.filename = filename;
    }
    #endregion

    #region Methods
    public List<Piece> startupLocations()
    {
        List<Piece> Pieces = new List<Piece>();
        return Pieces;
    }

    #endregion
}
