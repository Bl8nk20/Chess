using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Threading;

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
        /// closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// makes the GameOverOverlay and StartOverlay hidden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            GameOverOverlay.Visibility = Visibility.Hidden;
            StartOverlay.Visibility = Visibility.Hidden;
        }

        /// <summary>
        ///  makes the StartOverlay Visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartWindow(object sender, RoutedEventArgs e)
        {
            StartOverlay.Visibility = Visibility.Visible;
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
        ///  makes the NotImplementedOverlay Visible
        ///  starts the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotImplemented(object sender, RoutedEventArgs e)
        {
            NotImplementedOverlay.Visibility = Visibility.Visible;
            timer.Start();
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
    }
}
