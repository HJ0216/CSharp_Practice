using SignUpForm.ViewModels;
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

namespace SignUpForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModelMain();
        }

        private void textBoxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // MVVM Binding
            if (this.DataContext != null)
            { 
                ((ViewModelMain)this.DataContext).Password = ((PasswordBox)sender).Password; 
            }

            // PlaceHolder Visibility
            var passwordBox = sender as PasswordBox;

            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                textBlockPassword.Visibility = Visibility.Visible;
            }
            else
            {
                textBlockPassword.Visibility = Visibility.Collapsed;
            }
        }
    }
}