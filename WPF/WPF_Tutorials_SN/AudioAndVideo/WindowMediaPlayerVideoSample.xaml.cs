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
    /// Interaction logic for WindowMediaPlayerVideoSample.xaml
    /// </summary>
    public partial class WindowMediaPlayerVideoSample : Window
    {
        public WindowMediaPlayerVideoSample()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            if (mediaElementPlayer == null)
            {
                labelStatus.Content = "No file selected...";
                return;
            }

            if (mediaElementPlayer.NaturalDuration.HasTimeSpan)
            {
                labelStatus.Content = String.Format("{0} / {1}", mediaElementPlayer.Position.ToString(@"mm\:ss"), mediaElementPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            mediaElementPlayer.Play();
        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            mediaElementPlayer.Pause();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            mediaElementPlayer.Stop();
        }
    }
}