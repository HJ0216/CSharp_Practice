using Microsoft.Win32;
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
            if ((mediaElementPlayer.Source != null) && (mediaElementPlayer.NaturalDuration.HasTimeSpan) && (!_userIsDraggingSlider))
            {
                sliderProgress.Minimum = 0;
                sliderProgress.Maximum = mediaElementPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliderProgress.Value = mediaElementPlayer.Position.TotalSeconds;
            }
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                mediaElementPlayer.Source = new Uri(openFileDialog.FileName);
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((mediaElementPlayer != null) && (mediaElementPlayer.Source != null));
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaElementPlayer.Play();
            _mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaElementPlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            mediaElementPlayer.Stop();
            _mediaPlayerIsPlaying = false;
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mediaElementPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        private void sliderProgress_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _userIsDraggingSlider = true;
        }

        private void sliderProgress_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _userIsDraggingSlider = false;
            mediaElementPlayer.Position = TimeSpan.FromSeconds(sliderProgress.Value);
        }

        private void sliderProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelProgressStatus.Text = TimeSpan.FromSeconds(sliderProgress.Value).ToString(@"hh\:mm\:ss");
        }
    }
}
