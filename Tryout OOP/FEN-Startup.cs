using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Tryout_OOP;

internal class FEN_Startup
{
    /* 
     * Constructor : 
     *  string Regex
     *  
     * 1. Method : ConvertStringToList()
     *  1. Read a string from Json file (Constructor !)
     *  2. Convert String to List<Piece> Pieces
     * 
     * 2. Method : ConvertListtoString(List<Piece> Pieces) ->
     *  Convert List<Piece> Pieces to FEN string
     * 
     * 3. Method : OverWriteFile(List<string> MovesDictList)
     *  Save Last index of List to file
     */

    // Forsyth-Edwards-Notation(FEN)
    #region Properties
    private string filename;
    public string Filename
    {
        internal set { filename = value; }
        get { return filename; }
    }
    private string startpos;
    public string Startpos
    {
        get { return startpos; }
    }
    private string Regex = @"(\d|[kqbnrpKQBNRP])";
    #endregion

    #region Constructor
    public FEN_Startup()
    {
    }
    #endregion

    #region Methods
    /// <summary>
    /// Read string from file and convert the result to a list
    /// </summary>
    /// <returns></returns>
    public List<Piece> ConvertStringToList(string filename = "Default.txt")
    {
        if (File.Exists(filename))
        {
            using (StreamReader sr = new StreamReader(@"C:\" + filename))
            {
                string startpos = sr.ReadToEnd();
            }
        }

        List<Piece> Pieces = new List<Piece>();

        //string[] sectors = startpos.Split(" ");

        // create a new match dataatype
        Match m = Regex.Match(user_eingabe, Regex);

        // initialize an array with the lenght of the first exponent + 1
        string[] Coeff = new string[Convert.ToInt32(m.NextMatch().Value) + 1];

        // checking for every match of the regex
        foreach (Match match in new Regex(regex_expression).Matches(user_eingabe))
        {

            return Pieces;
        }
        // 1. List -> String (List<Piece>)
        // 2. String in List (stringListPiece)
        // 3. Overwrite Dictionary (filename, List(i)<string>) // i == Last index of list

        #endregion
    }
}