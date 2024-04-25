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

namespace Dialogs
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

        private void buttonSimpleMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!");
        }

        private void buttonMessageBoxWithTitle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!", "My App");
        }

        private void buttonMessageBoxWithButtons_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This MessageBox has extra options. \n\nHello, world?", "My App", MessageBoxButton.YesNoCancel);
        }

        private void buttonMessageBoxWithResponse_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Would you like to greet the world with a \"Hello, world\"?", "My App", MessageBoxButton.YesNoCancel);

            switch (messageBoxResult)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Hello to you too!", "My App");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }
        }

        private void buttonMessageBoxWithIcon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void buttonMessageBoxWithDefaultChoice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world?", "My App", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        }
    }
}