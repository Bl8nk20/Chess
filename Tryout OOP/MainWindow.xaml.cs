using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Tryout_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        public readonly List<TextBlock> TextBlocks = new List<TextBlock>();

        // duration for how long the items are highlighted
        private readonly Duration _openCloseDuration = new Duration(TimeSpan.FromSeconds(0.5));
        // creates a new timer
        DispatcherTimer timer = new DispatcherTimer();
        Game game = new Game();

        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            Setup();

            smallMenuContent.Height = 0;
            promationContentB.Height = 0;
            promationContentW.Height = 0;

            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 2);

            //
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        void Setup()
        {
            Game Game = new Game();
            Board Board = new Board(spielfeld, TextBlocks);
            Board.DrawPieces(TextBlocks, Game.InitialPieces());
        }

        //---------------------------------------- ------------------------------------------
        #region smallMenuBar
        /// <summary>
        /// animation for the small menu to open from the top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallMenuDropdownOpen(object sender, RoutedEventArgs e)
        {
            smallMenuInnerContent.Measure(new Size(smallMenuContent.MaxWidth, smallMenuContent.MaxHeight));
            DoubleAnimation heightAnimation = new DoubleAnimation(0, smallMenuInnerContent.DesiredSize.Height, _openCloseDuration);
            smallMenuContent.BeginAnimation(HeightProperty, heightAnimation);
        }

        /// <summary>
        /// animation for the small menu to close from the buttom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmallMenuDropdownClose(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation(0, _openCloseDuration);
            smallMenuContent.BeginAnimation(HeightProperty, heightAnimation);
        }
        #endregion

        #region Windows
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Resume(object sender, MouseButtonEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Hidden;
            StartOverlay.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// to open the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenu(object sender, MouseButtonEventArgs e)
        {
            StartOverlay.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// close the application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// to open the won window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Won(object sender, MouseButtonEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Visible;
        }
        #endregion

        #region Turns
        public void TurnWhite()
        {
            TurnLabel.Content = "White";
        }
        public void TurnBlack()
        {
            TurnLabel.Content = "Black";
        }
        #endregion

        #region Graveyard

        int c = 0;


        public List<Piece> Pieces;
        public void CounterG()
        {
            foreach (Piece piece in Pieces)
            {
                if (piece is Pawn && piece.IsKilled == true && piece.IsWhite)
                {
                    GCBP.Content = c++;
                    GCWP.Content = c++;
                }

            }
        }

        #endregion

        #region GameOver

        public void FF(object sender, RoutedEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Visible;
            GameState.Content = "~ FF ~";
        }

        public void Black_Won()
        {
            GameOverOverlay.Visibility = Visibility.Visible;
            GameState.Content = "~ Black Won ~";
        }

        public void White_Won()
        {
            GameOverOverlay.Visibility = Visibility.Visible;
            GameState.Content = "~ White Won ~";
        }

        public void Stalemate()
        {
            GameOverOverlay.Visibility = Visibility.Visible;
            GameState.Content = "~ Stalemate ~";
        }
        #endregion

        #region Promotion
        /// <summary>
        /// to open the promotion window Black
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromotionDropdownOpenB(object sender, RoutedEventArgs e)
        {
            promationInnerContentB.Measure(new Size(promationContentB.MaxWidth, promationContentB.MaxHeight));
            DoubleAnimation promotionAnimationB = new(0, promationInnerContentB.DesiredSize.Height, _openCloseDuration);
            promationContentB.BeginAnimation(HeightProperty, promotionAnimationB);
        }

        /// <summary>
        /// to open the promotion window White
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromotionDropdownOpenW(object sender, RoutedEventArgs e)
        {
            promationInnerContentW.Measure(new Size(promationContentW.MaxWidth, promationContentW.MaxHeight));
            DoubleAnimation promotionAnimationW = new DoubleAnimation(0, promationInnerContentW.DesiredSize.Height, _openCloseDuration);
            promationContentW.BeginAnimation(HeightProperty, promotionAnimationW);
        }

        /// <summary>
        /// to close the promation window Black
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromotionDropdownCloseB(object sender, RoutedEventArgs e)
        {
            DoubleAnimation promotionAnimationB = new DoubleAnimation(0, _openCloseDuration);
            promationContentB.BeginAnimation(HeightProperty, promotionAnimationB);
        }

        /// <summary>
        /// to close the promation window White
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PromotionDropdownCloseW(object sender, RoutedEventArgs e)
        {
            DoubleAnimation promotionAnimationW = new DoubleAnimation(0, _openCloseDuration);
            promationContentW.BeginAnimation(HeightProperty, promotionAnimationW);
        }

        /// <summary>
        /// promotion white
        /// </summary>
        private void WQ(object sender, MouseButtonEventArgs e)
        {
            promationContentW.Visibility = Visibility.Hidden;
        }
        private void WR(object sender, MouseButtonEventArgs e)
        {
            promationContentW.Visibility = Visibility.Hidden;
        }
        private void WB(object sender, MouseButtonEventArgs e)
        {
            promationContentW.Visibility = Visibility.Hidden;
        }
        private void WN(object sender, MouseButtonEventArgs e)
        {
            promationContentW.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// promotion black
        /// </summary>
        private void BQ(object sender, MouseButtonEventArgs e)
        {
            promationContentB.Visibility = Visibility.Hidden;
        }
        private void BR(object sender, MouseButtonEventArgs e)
        {
            promationContentB.Visibility = Visibility.Hidden;
        }
        private void BB(object sender, MouseButtonEventArgs e)
        {
            promationContentB.Visibility = Visibility.Hidden;
        }
        private void BN(object sender, MouseButtonEventArgs e)
        {
            promationContentB.Visibility = Visibility.Hidden;
        }


        #endregion

        #region NotImplementedYet
        /// <summary>
        /// makes the NotImplementedOverlay Hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tick(object sender, EventArgs e)
        {
            NotImplementedOverlay.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// place holder fo thing that i was to lazy to implement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notImplementedYet(object sender, MouseButtonEventArgs e)
        {
            NotImplementedOverlay.Visibility = Visibility.Visible;
            timer.Start();
        }
        #endregion

        #endregion
    }
}


