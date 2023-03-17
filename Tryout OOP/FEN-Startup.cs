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
    #endregion

    #region Constructor
    public FEN_Startup(string filename)
    {
        string Regex = @"(\d|[kqbnrpKQBNRP])";
        this.filename = filename;

    }
    #endregion

    #region Methods
    void startupLocations()
    {
        
    }

    #endregion
}
