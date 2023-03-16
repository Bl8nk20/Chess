using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace Tryout_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBlock[,] textBlocks = new TextBlock[8, 8];
        List<Piece> pieces = new List<Piece>();
        AdditionalLogic? Logic;
        Player? Player1;
        Player? Player2;
        PlayerTurn? playerTurn;
        Piece? movedPiece;

        public MainWindow()
        {
            InitializeComponent();
            //
            Setup();
        }

        /// <summary>
        /// 
        /// </summary>
        void Setup()
        {
            Player1 = new Player(true);
            Player2 = new Player();
            pieces = new List<Piece>(); // initialize the pieces list
            Logic = new AdditionalLogic(pieces, textBlocks, movedPiece);
            pieces = Logic.InitialPieces();
            playerTurn = new PlayerTurn(textBlocks, pieces);
            Board Board = new Board(pieces, textBlocks, spielfeld);
            Board.DrawBoard(spielfeld);
            Game Game = new Game(Player1, Player2, textBlocks, textboxturns, textboxPlayer);
            
            Game.playerMovement();
        }
    }

}