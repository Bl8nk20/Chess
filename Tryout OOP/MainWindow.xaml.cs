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
        public readonly List<TextBlock> TextBlocks = new List<TextBlock>();

        // duration for how long the items are highlighted
        private readonly Duration _openCloseDuration = new Duration(TimeSpan.FromSeconds(0.5));
        // creates a new timer
        DispatcherTimer timer = new DispatcherTimer();

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

        /// <summary>
        /// 
        /// </summary>
        void Setup()
        {
            Game Game = new Game();
            Board Board = new Board(spielfeld, TextBlocks);
            Board.DrawPieces(TextBlocks, Game.InitialPieces());
            // check if game has ended
            if (Game.isEnd())
            {
                FEN_Startup fEN_Startup = new FEN_Startup();
                fEN_Startup.OverWriteFile(Board.TextBlocks, Game.Pieces);
                Close();
            }
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
        /// opens the window to the coressponding color
        /// </summary>

        /*
        private void PawnAtTheEnd()
        {
            if(pawn reached the end of each side)
            {
                //check if the pawn is black or white 
                if (isWhite ? '\u2657' : '\u265D')
                {
                    PromotionDropdownOpenB();
                    PromotionDropdownOpenW();
                }
            }
        }

        /// <summary>
        /// closes window and change the pawn to the selected piece
        /// </summary>
        private void ChossenPiece()
        {
            piece = selected piece
            switch(piece)
            {
                case 1:
                    pawn changes to Queen;
                    PromotionDropdownCloseB();
                    PromotionDropdownCloseW();

                case 2:
                    pawn changes to Rook;
                    PromotionDropdownCloseB();
                    PromotionDropdownCloseW();

                case 3:
                    pawn changes to Bishop;
                    PromotionDropdownCloseB();
                    PromotionDropdownCloseW();

                case 4:
                    pawn changes to Knight;
                    PromotionDropdownCloseB();
                    PromotionDropdownCloseW();       
            }
        }
        */
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

    }
}


