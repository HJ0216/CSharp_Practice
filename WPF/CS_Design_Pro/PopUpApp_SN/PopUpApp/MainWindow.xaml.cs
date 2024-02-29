using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PopUpApp
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

        private void Home_MouseEnter(object sender, MouseEventArgs e)
        {
            PopUp_UC.PlacementTarget = Home;
            PopUp_UC.Placement = PlacementMode.Right;
            PopUp_UC.IsOpen = true;
            Header.PopUpText.Text = "Home";
        }

        private void Home_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp_UC.Visibility = Visibility.Collapsed;
            PopUp_UC.IsOpen = false;
        }

        private void Profile_MouseEnter(object sender, MouseEventArgs e)
        {
            PopUp_UC.PlacementTarget = Profile;
            PopUp_UC.Placement = PlacementMode.Right;
            PopUp_UC.IsOpen = true;
            Header.PopUpText.Text = "Profile";
        }

        private void Profile_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp_UC.Visibility = Visibility.Collapsed;
            PopUp_UC.IsOpen = false;
        }

        private void Settings_MouseEnter(object sender, MouseEventArgs e)
        {
            PopUp_UC.PlacementTarget = Settings;
            PopUp_UC.Placement = PlacementMode.Right;
            PopUp_UC.IsOpen = true;
            Header.PopUpText.Text = "Settings";
        }

        private void Settings_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUp_UC.Visibility = Visibility.Collapsed;
            PopUp_UC.IsOpen = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}