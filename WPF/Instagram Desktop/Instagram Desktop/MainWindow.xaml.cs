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

namespace Instagram_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtBlockSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtBlockSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSearch.Text) && txtSearch.Text.Length > 0)
            {
                txtSearch.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtSearch.Visibility = Visibility.Visible;
            }
        }
    }
}