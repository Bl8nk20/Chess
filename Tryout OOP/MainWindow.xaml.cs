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
        Player? Player1;
        Player? Player2;
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
            Player1.IsTurn = true;

            Player2 = new Player();
            
            List<Piece> pieces = new List<Piece>(); // initialize the pieces list
            
            Board Board = new Board();
            Board.DrawBoard(textBlocks);
            
            Game Game = new Game();
            pieces = Game.InitialPieces();
            Game.playerMovement();
        }
    }

}