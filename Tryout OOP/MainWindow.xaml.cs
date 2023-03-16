using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Tryout_OOP;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    TextBlock[,] textBlocks = new TextBlock[8, 8];
    List<Pieces> pieces = new List<Pieces>();
    Player Player1;
    Player Player2;
    PlayerTurn playerTurn;
    AdditionalLogic Logic;
    Pieces movedPiece;

    public MainWindow()
    {
        InitializeComponent();
        Setup();    
    }

    void Setup()
    {
        Logic = new AdditionalLogic(pieces, textBlocks, movedPiece);
        Player1 = Logic.Player1;
        Player2 = Logic.Player2;
        pieces = Logic.InitialPieces();
        playerTurn = new PlayerTurn(textBlocks, pieces);
        Board Board = new Board(playerTurn.playerturns, pieces, textBlocks, spielfeld, textboxturns, textboxPlayer);
        Board.DrawBoard(spielfeld);
        Game Game = new Game(Player1, Player2, textBlocks);
        Game.Playing();
    }
}

