using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Tryout_OOP;

public class Player
{
    #region Properties
    private bool isWhite;
    public bool IsWhite
    {
        get { return isWhite; }
    }
    private bool isTurn;
    public bool IsTurn
    {
        set { isTurn = value; }
        get { return isTurn; }
    }
    private FEN_Startup FEN_Startup;

    private List<Piece> pieces;
    public List<Piece> Pieces
    {
        get { return pieces; }
        set { pieces = value; }
    }

    private Piece selectedPiece;
    public Piece SelectedPiece
    {
        get { return selectedPiece; }
        set { selectedPiece = value; }
    }
    #endregion

    #region Constructor
    public Player(bool isWhite = false)
    {
        FEN_Startup = new FEN_Startup();
        this.isWhite = isWhite;
        this.isTurn = false;
        Pieces = CreatePieces();
    }

    // \u2654 => white king
    // \u2655 => white Queen
    // \u2656 => white rook
    // \u2657 => white bishop
    // \u2658 => white knight
    // \u2659 => white pawn
    // \u265A => black King
    // \u265B => black Queen
    // \u265C => black Rook
    // \u265D => black bishop
    // \u265E => black knight
    // \u265F => black Pawn

    #endregion

    #region Methods
    public void SwitchTurns()
    {
        isTurn = !isTurn;
    }

    /// <summary>
    /// Method to check if the Player is allowed
    /// to move the piece to that specific postion
    /// </summary>
    /// <param name="piece"></param>
    /// <returns></returns>
    public bool CanMove(Piece piece)
    {
        // Check if the piece belongs to the player and is allowed to move
        if (selectedPiece == null || selectedPiece.IsWhite != this.IsWhite || !this.IsTurn)
        {
            return false;
        }

        // If all checks pass, the player can move the piece
        return true;
    }

    /// <summary>
    /// Initial Setup to set the Pieces to their official start positions
    /// </summary>
    /// <returns></returns>
    public List<Piece> CreatePieces()
    {
        // call fen class to convert a string in a list with the pieces
        List<Piece> CompleteFENList = FEN_Startup.ConvertStringToList();
        Pieces = new List<Piece>();
        // Looping for the complete list and search for own colored pieces
        foreach (Piece piece in CompleteFENList)
        {
            if (this.isWhite == piece.IsWhite)
            {
                Pieces.Add(piece);
            }
        }
        return Pieces;
    }

    /// <summary>
    /// Method to update the List with the 
    /// Pieces to remove the captured Piece
    /// looping for each element in the list and removing it
    /// , if the bool "IsKilled" is equal to true
    /// </summary>
    /// <param name="pieces">list with every pieces / current pieces in the game</param>
    public void updateList(List<Piece> pieces)
    {
        // looping and checking if any piece is lately updated
        foreach (var piece in pieces)
        {
            // check if bool variable is true and if so remove the piece from the board
            if (piece.IsKilled)
            {
                pieces.Remove(piece);
                break;
            }
        }
    }


    #region Piece Searching

    /// <summary>
    /// search the King of the current player
    /// </summary>
    /// <param name="currentPlayer"></param>
    /// <returns></returns>
    public Piece searchKing()
    {
        foreach (Piece piece in pieces)
        {
            if (piece is King)
            {
                return piece;
            }
        }

        return null;
    }

<<<<<<< Updated upstream
=======
    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the List, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    internal Piece searchPiece(PointStruct p)
    {
        // Find Piece to move
        foreach (var piece in pieces)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (piece.Position.Equals(p))
            {
                return piece;
            }
        }
        return null;
    }
    #endregion

    #region Special Moves
>>>>>>> Stashed changes
    /// <summary>
    /// A Method to search The ChessPieces 
    /// in the List, which should be moved
    /// </summary>
    /// <param name="p"></param>
    /// <returns>nothing (void)</returns>
    internal Piece searchPiece(PointStruct p)
    {
<<<<<<< Updated upstream
        // Find Piece to move
        foreach (var piece in pieces)
        {
            // if it matches set the movedPiece to the piece at the corresponding index
            if (piece.Position.Equals(p))
            {
                return piece;
            }
        }
        return null;
    }
    #endregion

    #region Special Moves

    #region Castling

    bool RightCastlingPossible(Piece king, Piece rook, int y)
    {
        if (rook is not Rook)
        {
            return false;
        }

        if (rook.HasMoved || king.HasMoved || king.IsUnderAttack)
        {
            return false;
        }

        for (int x = king.Position.X + 1; x < rook.Position.X; x++)
        {
            foreach (var piece in pieces)
            {
                if (piece.Position.Equals(new PointStruct(x, y)))
                {
                    return false;
                }

            }
        }
        return true;
    }

    bool LeftCastlingPossible(Piece king, Piece rook, int y)
    {
        if (rook is not Rook)
        {
            return false;
        }

        if (rook.HasMoved || king.HasMoved || king.IsUnderAttack)
        {
            return false;
        }

        for (int x = king.Position.X - 1; x > rook.Position.X; x--)
        {
            foreach (var piece in pieces)
            {
                if (piece.Position.Equals(new PointStruct(x, y)))
                {
                    return false;
                }

            }
        }
        return true;
    }

    public void Castling(Piece King, PointStruct TargetPoint)
    {
        int y = this.isWhite ? 0 : 7;

        Piece rook_left = searchPiece(new PointStruct(0, y));
        Piece rook_right = searchPiece(new PointStruct(7, y));

        if (RightCastlingPossible(King, rook_right, y)
            && TargetPoint.X > King.Position.X + 1)
        {
            King.Move(new PointStruct(King.Position.X + 2, y));
            rook_right.Move(new PointStruct(King.Position.X - 1, y));
        }
        if (LeftCastlingPossible(King, rook_left, y)
            && TargetPoint.X < King.Position.X - 1)
        {
            King.Move(new PointStruct(King.Position.X - 2, y));
            rook_left.Move(new PointStruct(King.Position.X + 1, y));
        }
    }

    #endregion

    #region Promotion
    //void Promotion()
    //{
    //    MainWindow Promotion = (MainWindow)Application.Current.MainWindow;
    //    /* 
    //     * First check if a pawn is at the end of the board
    //     * then open the promotion window
    //     * 
    //     * ! Waiting for Phils events and windows !
    //     */

    //    // check if its black or white
    //    if (!SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 0)))
    //    {
    //        // Window
    //        //Promotion.promationContentB();
    //        // piece needed to replace either with the user input or a specific piece
    //        SelectedPiece.IsKilled = true;
    //        //pieces.Add(new ...(movedPiece.Position));

    //    }

    //    if (SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 7)))
    //    {
    //        // Window
    //        //Promotion.promationContentW();

    //        // piece needed to replace either with the user input or a specific piece
    //        SelectedPiece.IsKilled = true;
    //        //pieces.Add(new ...(movedPiece.Position));

    //    }
    //}
    #endregion

    #endregion

    #endregion
=======

        // Castling
        // check if movedPiece is from type King
        // check if king and one of the Rooks haven´t been moved yet
        // check if the way is free (no bishop or knight or other piece is on same line)
        // move king two steps in rooks direction -> place rook on the left or right nearby
        // set king and rook to moved
        if(selectedPiece is King)
        {
            Castling(selectedPiece);
        }

        // Promotion
        // check if pawn has reached end of board
        // ask player to which piece the pawn should be promoted
        // remove pawn -> replace it with players choice
        if (SelectedPiece is Pawn)
        {
            //Promotion();
        }
    }

    #region Castling

    bool RightCastlingPossible(Piece king, Piece rook, int y)
    {
        if (rook is not Rook)
        {
            return false;
        }

        if (rook.HasMoved || king.HasMoved || king.IsUnderAttack)
        {
            return false;
        }

        for (int x = king.Position.X + 1; x < rook.Position.X; x++)
        {
            foreach (var piece in pieces)
            {
                if (piece.Position.Equals(new PointStruct(x, y)))
                {
                    return false;
                }

            }
        }
        return true;
    }

    bool LeftCastlingPossible(Piece king, Piece rook, int y)
    {
        if (rook is not Rook)
        {
            return false;
        }

        if (rook.HasMoved || king.HasMoved || king.IsUnderAttack)
        {
            return false;
        }

        for (int x = king.Position.X - 1; x > rook.Position.X; x--)
        {
            foreach (var piece in pieces)
            {
                if (piece.Position.Equals(new PointStruct(x, y)))
                {
                    return false;
                }

            }
        }
        return true;
    }

    public void Castling(Piece King)
    {
        int y = this.isWhite ? 0 : 7;

        Piece rook_left = searchPiece(new PointStruct(0, y));
        Piece rook_right = searchPiece(new PointStruct(7, y));

        if (RightCastlingPossible(King, rook_right, y))
        {
            King.Move(new PointStruct(King.Position.X + 2, y));
            rook_right.Move(new PointStruct(King.Position.X - 1, y));
        }
        if (LeftCastlingPossible(King, rook_left, y))
        {
            King.Move(new PointStruct(King.Position.X - 2, y));
            rook_left.Move(new PointStruct(King.Position.X + 1, y));
        }
    }

    #endregion

    #region Promotion
    //void Promotion()
    //{
    //    MainWindow Promotion = (MainWindow)Application.Current.MainWindow;
    //    /* 
    //     * First check if a pawn is at the end of the board
    //     * then open the promotion window
    //     * 
    //     * ! Waiting for Phils events and windows !
    //     */

    //    // check if its black or white
    //    if (!SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 0)))
    //    {
    //        // Window
    //        //Promotion.promationContentB();
    //        // piece needed to replace either with the user input or a specific piece
    //        SelectedPiece.IsKilled = true;
    //        //pieces.Add(new ...(movedPiece.Position));

    //    }

    //    if (SelectedPiece.IsWhite && SelectedPiece.Position.Equals(new PointStruct(SelectedPiece.Position.X, 7)))
    //    {
    //        // Window
    //        //Promotion.promationContentW();

    //        // piece needed to replace either with the user input or a specific piece
    //        SelectedPiece.IsKilled = true;
    //        //pieces.Add(new ...(movedPiece.Position));

    //    }
    //}

>>>>>>> Stashed changes

}
#endregion

#endregion

#endregion

