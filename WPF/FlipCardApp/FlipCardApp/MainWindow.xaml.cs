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

namespace FlipCardApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            initData();
        }

        private void initData()
        {
            var data = new[]
            {
                new {Name = "James"}
                , new {Name = "Mike"}
                , new {Name = "John"}
                , new {Name = "Luke"}
                , new {Name = "Oscar"}
                , new {Name = "Charles"}
            };

            myListbox.ItemsSource = data;
        }

        private void tileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myListbox.Layout = Layout.Tile;
        }

        private void listMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myListbox.Layout = Layout.List;
        }
    }
}