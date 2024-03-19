using Microsoft.Win32;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AudioAndVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer _player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _player.Open(new Uri(openFileDialog.FileName));
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 타이머가 작동하는 주기
            timer.Tick += timer_Tick; // Interval마다 메서드 실행
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            if (_player.Source == null)
            {
                labelStatus.Content = "No file Selected..";
                return;
            }

            labelStatus.Content = String.Format("{0} / {1}", _player.Position.ToString(@"mm\:ss"), _player.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }

        private void buttonAsterisk_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void buttonBeep_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Beep.Play();
        }

        private void buttonExclamation_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private void buttonHand_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Hand.Play();
        }

        private void buttonQuestion_Click(object sender, RoutedEventArgs e)
        {
            SystemSounds.Question.Play();
        }

        private void buttonOpenAudioFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _player.Open(new Uri(openFileDialog.FileName));
                _player.Play();
            }
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            _player.Play();
        }

        private void buttonPause_Click(object sender, RoutedEventArgs e)
        {
            _player.Pause();
        }

        private void buttonStop_Click(object sender, RoutedEventArgs e)
        {
            _player.Stop();
        }
    }
}