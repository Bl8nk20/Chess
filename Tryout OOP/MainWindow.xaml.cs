using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;



namespace Tryout_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBlock> TextBlocks = new List<TextBlock>();
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
            Game Game = new Game();
            Board Board = new Board(spielfeld, TextBlocks);
            //Board.DrawBoard();
            Board.DrawPieces(TextBlocks, Game.InitialPieces());
            if (Game.isEnd())
            {
                Close();
            }
        }
    }

}