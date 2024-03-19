using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AudioAndVideo
{
    /// <summary>
    /// Interaction logic for WindowWPFMediaPlayer.xaml
    /// </summary>
    public partial class WindowWPFMediaPlayer : Window
    {
        private bool _mediaPlayerIsPlaying = false;
        private bool _userIsDraggingSlider = false;

        public WindowWPFMediaPlayer()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {

        }

        private void sliderProgress_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {

        }

        private void sliderProgress_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {

        }

        private void sliderProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
