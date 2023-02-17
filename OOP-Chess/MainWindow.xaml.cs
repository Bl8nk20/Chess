using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;
using OOP_Chess;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // duration for how long the items are highlighted
        private readonly Duration _openCloseDuration = new Duration(TimeSpan.FromSeconds(0.5));
        // creates a new timer
        DispatcherTimer timer = new DispatcherTimer();

        Pieces[] pieces = new Pieces[1];
        TextBlock[,] textBlocks = new TextBlock[8, 8];
        /// <summary>
        /// sets the small menu window height to zero
        /// timer with a 2 second span
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            dropdownContent.Height = 0;

            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = new TimeSpan(0, 0, 2);

            pieces[0] = new Rook(2, 3, false);

            DrawBoard();
        }

        private void DrawBoard()
        {
            // load the board to the gui
            for (byte i = 0; i < 8; i++)
            {
                for (byte j = 0; j < 8; j++)
                {
                    TextBlock b = new TextBlock();
                    // draw the chessboard
                    b.Width = 72.5;
                    b.Height = 72.5;
                    b.Text = i.ToString();
                    b.FontSize = 25;
                    b.Background = ((i + j) % 2 != 0) ? Brushes.White : Brushes.LightGray;
                    spielfeld.Children.Add(b);
                    textBlocks[i, j] = b;
                    Canvas.SetLeft(b, 72.5 * i);
                    Canvas.SetBottom(b, 72.5 * j);
                }
            }

            for(byte i = 0; i < 8; i++)
            {
                for(byte j = 0; j < 8; j++)
                {
                    textBlocks[i, j].Text = "";
                    for (byte k = 0; k < pieces.Length; k++)
                    {
                        if (pieces[k].X == i && pieces[k].Y == j)
                        {
                            textBlocks[i, j].Text = pieces[k].Look.ToString();
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// animation for the small menu to open from the top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenDropdown(object sender, RoutedEventArgs e)
        {
            dropdownInnerContent.Measure(new Size(dropdownContent.MaxWidth, dropdownContent.MaxHeight));
            DoubleAnimation heightAnimation = new DoubleAnimation(0, dropdownInnerContent.DesiredSize.Height, _openCloseDuration);
            dropdownContent.BeginAnimation(HeightProperty, heightAnimation);
        }

        /// <summary>
        /// animation for the small menu to close from the buttom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseDropdown(object sender, RoutedEventArgs e)
        {
            DoubleAnimation heightAnimation = new DoubleAnimation(0, _openCloseDuration);
            dropdownContent.BeginAnimation(HeightProperty, heightAnimation);
        }

        /// <summary>
        /// makes the GameOverOverlay Visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WonWindow(object sender, RoutedEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// makes the NotImplementedOverlay Hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_tick(object sender, EventArgs e)
        {
            NotImplementedOverlay.Visibility = Visibility.Hidden;
        }

        private void Resume(object sender, MouseButtonEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Hidden;
            StartOverlay.Visibility = Visibility.Hidden;
        }

        private void MainMenu(object sender, MouseButtonEventArgs e)
        {
            StartOverlay.Visibility = Visibility.Visible;
        }

        private void Exit(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Won(object sender, MouseButtonEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Visible;
        }

        private void notImplementedYet(object sender, MouseButtonEventArgs e)
        {
            NotImplementedOverlay.Visibility = Visibility.Visible;
            timer.Start();
        }
    }
}
