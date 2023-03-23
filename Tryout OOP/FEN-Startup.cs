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

    #region Properties

    // prerequirements
    private readonly string _filename = "Default.txt";
    private readonly Stream _fileStream;
    private readonly StreamReader _streamReader;
    private readonly StreamWriter streamWriter;

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

    private string[] sectors;
    public string[] Sectors
    {
        get { return sectors; }
        set { sectors = value; }
    }

    #endregion

    #region Constructor
    public FEN_Startup()
    {
        _filename = "Default.txt";
        this._fileStream = new FileStream(_filename, FileMode.OpenOrCreate);
        this._streamReader = new StreamReader(_fileStream);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Read string from file and convert the result to a list
    /// </summary>
    /// <param name="filename"></param>
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

        int row = 0;
        int column = 7;

        // checking for every match of the regex
        foreach (char symbol in sectors[0])
        {
            // check for each new "Linebreak" in string
            if (symbol == '/')
            {
                row = 0;
                column--;
            }
            else
            {
                // check if the char is a number or not
                if (char.IsDigit(symbol))
                {
                    // Count the amount of numbers up
                    row += (int)char.GetNumericValue(symbol);
                }
                else
                {
                    // check if piece is White or Black
                    bool color = (char.IsUpper(symbol)) ? true : false;
                    switch (char.ToLower(symbol))
                    {
                        case 'p':
                            Pieces.Add(new Pawn(new PointStruct(row, column), color));
                            break;
                        case 'b':
                            Pieces.Add(new Bishop(new PointStruct(row, column), color));
                            break;
                        case 'n':
                            Pieces.Add(new Knight(new PointStruct(row, column), color));
                            break;
                        case 'r':
                            Pieces.Add(new Rook(new PointStruct(row, column), color));
                            break;
                        case 'q':
                            Pieces.Add(new Queen(new PointStruct(row, column), color));
                            break;
                        case 'k':
                            Pieces.Add(new King(new PointStruct(row, column), color));
                            break;
                    }
                    row++;
                }
            }

        }
        _streamReader.Dispose();
        _fileStream.Dispose();

        return Pieces;
    }

    /// <summary>
    /// 1. Loop through every Textblock in List<TextBlock> TextBlocks
    /// Check 
    /// </summary>
    /// <param name="pieces"></param>
    /// <returns></returns>
    string ConvertListToString(List<TextBlock> TextBlockList, List<Piece> pieces)
    {
        string FinalFEN;
        string[] FENParts = new string[6];
        for (int rank = 7; rank >= 0; rank--)
        {
            int numEmptyFiles = 0;
            for (int file = 0; file < 8; file++)
            {
                int i = rank * 8 + file;
                if (TextBlockList[i].Text == "")
                {
                    numEmptyFiles += 1;
                }
                foreach(Piece piece in pieces)
                {
                    // add each piece to the string
                    switch (piece)
                    {
                        case Pawn:
                            FENParts[0] += (piece.IsWhite) ? "P" : "p";
                            break;
                        case Bishop:
                            FENParts[0] += (piece.IsWhite) ? "B" : "b";
                            break;
                        case Knight:
                            FENParts[0] += (piece.IsWhite) ? "N" : "n";
                            break;
                        case Rook:
                            FENParts[0] += (piece.IsWhite) ? "R" : "r";
                            break;
                        case Queen:
                            FENParts[0] += (piece.IsWhite) ? "Q" : "q";
                            break;
                        case King:
                            FENParts[0] += (piece.IsWhite) ? "K" : "k";
                            break;
                    }
                }

            }
        }
        // Implement who´s turn it is string[1]
        FENParts[1] = " w";

        // Implement CastlingRights string[2]
        FENParts[2] = " KQkq";

        // Implement enPassant Field string[3]
        FENParts[3] = " -";
        // Implement 50 MoveCounter string[4]
        FENParts[4] = " 0";

        // Implement Full MoveCounter should be one at start and +=1 each time black´s turn has ended
        FENParts[5] = " 1";

        // add every part to one complete string 
        FinalFEN = FENParts.ToString();

        return FinalFEN;
    }

    /// <summary>
    /// A Method to write / Overwrite a File so that you can load it later again if you like to
    /// </summary>
    /// <param name="MovesDictList">a List with the generated String per move</param>
    /// <param name="filename">Default Value is "LastGame.txt"</param>
    void OverWriteFile(List<string> MovesDictList, string filename="LastGame.txt")
    {

    }

    #endregion
}