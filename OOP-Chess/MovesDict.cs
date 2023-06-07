using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Chess;

internal class MovesDict
{
    /*
     * ! TASK for Jonas !
     * 
     * Constructor : 
     *  FEN_StartUp FEN_StartUp = new FEN_StartUp()
     *  
     * 1. Method : SaveBoard(List<Piece> Pieces) -> string
     *  1. Call MovesDict EVERY Playerturn
     *  2. Convert PieceList to string
     *  
     * 2. Method : ExpandMovesList(SaveBoard(List<Piece> Pieces)) -> List<string> MovesDictList
     *  1. Add String to MovesDictList
     * 
     * Trigger : EVERY begin of Playerturn & GameEnd
     * 3. Method : SaveMoveInFile() -> void
     *  1. Call ExpandMovesList()
     *  2. Call FEN_Startup.OverWriteFile(List<string> MovesDictList)
     */
    #region Properties
    private FEN_Startup Fen;
    #endregion

    #region Constructor
    public MovesDict()
    {
        FEN_Startup Fen = new FEN_Startup();
    }

    #endregion

    #region Methods
    /// <summary>
    /// Returns a string according to the last played move
    /// </summary>
    string SaveBoard()
    {
        // needs to be implemented
        string CurrentBoard = "";
        return CurrentBoard;
    }
    #endregion
}
