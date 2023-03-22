using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tryout_OOP;

internal class FEN_Startup
{
    /* 
     * Constructor : 
     *  string Regex
     *  
     * 1. Method : ReadAndArrayGeneration() -> string[]
     *  1. Read a string from Json file (Constructor !)
     *  2. Split string in array up
     *  
     * 2. Method : ConvertStringToList()
     *  1. Read the first index of string array
     *  2. Convert String to List<Piece> Pieces
     * 
     * 3. Method : DefinePlayerturn() -> bool ?
     *  1. Read the second index of the array
     *  2. Decide wether it is "w" or "b"
     * 
     * 4. Method : ConvertListtoString(List<Piece> Pieces) ->
     *  Convert List<Piece> Pieces to FEN string
     * 
     * 5. Method : OverWriteFile(List<string> MovesDictList)
     *  Save Last index of List to file
     */

    // Forsyth-Edwards-Notation(FEN)

    #region Fields

    private static Dictionary<char, Type> pieceNotation = new Dictionary<char, Type>
        {
            { 'k', typeof(King)  } ,
        { 'q', typeof(Queen)} ,
        { 'b', typeof(Bishop)} ,
        { 'n', typeof(Knight)} ,
        { 'r', typeof(Rook)} ,
        { 'p', typeof(Pawn)}
        };
    #endregion Fields

    #region Properties

    // prerequirements
    private readonly string _filename = "Default.txt";
    private readonly Stream _fileStream;
    private readonly StreamReader _streamReader;

    private List<TextBlock> textBlockList;
    public List<TextBlock> TextBlockList
    {
        get { return textBlockList; }
        set { textBlockList = value; }
    }

    private string startpos;
    public string Startpos
    {
        get { return startpos; }
        set { startpos = value; }
    }
    #endregion

    #region Constructor
    public FEN_Startup(List<TextBlock> TextBlockList)
    {
        this.TextBlockList = TextBlockList;
        _filename = "Default.txt";
        _fileStream = new FileStream(_filename, FileMode.OpenOrCreate);
        _streamReader = new StreamReader(_fileStream);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Read string from file and convert the result to a list
    /// </summary>
    /// <returns></returns>
    public List<Piece> ConvertStringToList(string filename = "Default.txt")
    {
        // read the file to get the fen string
        startpos = _streamReader.ReadToEnd();
        // create a new Empty list
        List<Piece> Pieces = new List<Piece>();

        // split the string in an array,
        // where each index describes another
        // part of the fen Notation
        string[] sectors = startpos.Split(" ");

        int file = 0;
        int rank = 7;

        // checking for every match of the regex
        foreach (char symbol in sectors[0])
        {
            // check for each new "Linebreak" in string
            if (symbol == '/')
            {
                file = 0;
                rank--;
            }
            else
            {
                // check if the char is a number or not
                if (char.IsDigit(symbol))
                {
                    // Count the amount of numbers up
                    file += (int)char.GetNumericValue(symbol);
                }
                else
                {
                    // check if piece is White or Black
                    bool color = (char.IsUpper(symbol)) ? true : false;
                    switch (char.ToLower(symbol))
                    {
                        case 'k':
                            Pieces.Add(new King(new PointStruct(rank * 8, file), color));
                            break;
                        case 'q':
                            Pieces.Add(new Queen(new PointStruct(rank * 8, file), color));
                            break;
                        case 'n':
                            Pieces.Add(new Knight(new PointStruct(rank * 8, file), color));
                            break;
                        case 'b':
                            Pieces.Add(new Bishop(new PointStruct(rank * 8, file), color));
                            break;
                        case 'r':
                            Pieces.Add(new Rook(new PointStruct(rank * 8, file), color));
                            break;
                        case 'p':
                            Pieces.Add(new Pawn(new PointStruct(rank * 8, file), color));
                            break;
                    }
                    file++;
                }
            }

        }
        _streamReader.Dispose();
        _fileStream.Dispose();

        return Pieces;
    }

    string ConvertListToString(List<Piece> pieces)
    {
        string List = "";
        return List;
    }

    void OverWriteFile(List<string> MovesDictList)
    {

    }
    // 1. List -> String (List<Piece>)
    // 2. String in List (stringListPiece)
    // 3. Overwrite Dictionary (filename, List(i)<string>) // i == Last index of list

    #endregion

    #region Deconstructor

    //~FEN_Startup()
    //{
    //    _streamReader.Dispose();
    //    _fileStream.Dispose();
    //}
    #endregion
}
