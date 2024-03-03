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

namespace Basic_Controls
{
    /// <summary>
    /// Interaction logic for ImageSampleWindow.xaml
    /// </summary>
    public partial class ImageSampleWindow : Window
    {
        public ImageSampleWindow()
        {
            InitializeComponent();
        }

        private void buttonLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imageDynamicSource.Source = new BitmapImage(fileUri);
            }
        }

        private void buttonLoadFromResource_Click(object sender, RoutedEventArgs e)
        {
            Uri resourceUri = new Uri("/Resources/loopy_rose.png", UriKind.Relative);
            imageDynamicSource.Source = new BitmapImage(resourceUri);
        }
    }
}
