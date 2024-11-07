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

namespace CardWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> monthTxt = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<string> yearTxt = new List<string>() { "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

        public MainWindow()
        {
            InitializeComponent();

            dateCbx.ItemsSource = monthTxt;
            dateCbx.SelectedIndex = 0;

            monthCbx.ItemsSource = yearTxt;
            monthCbx.SelectedIndex = 0;
        }

        private void tbCardXPnl_TextChanged(object sender, TextChangedEventArgs e)
        {
            int count = tbCardXPnl.Text.Length;

            if (count < 5)
            {
                num1.Text = tbCardXPnl.Text;
            }
            else if (count > 4 && count < 9)
            {
                num1.Text = tbCardXPnl.Text.Substring(4);
            }
            else if (count > 8 && count < 12)
            {
                num1.Text = tbCardXPnl.Text.Substring(8);
            }
            else if (count > 12 && count < 17)
            {
                num1.Text = tbCardXPnl.Text.Substring(12);
            }
        }

        private void tbHolderXPnl_TextChanged(object sender, TextChangedEventArgs e)
        {
            cardHolder.Text = tbHolderXPnl.Text;
        }

        private void dateCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mon = monYearCard.Text;
            monYearCard.Text = dateCbx.SelectedValue.ToString() + mon.Remove(0, 2);
        }

        private void monthCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string mon = monYearCard.Text;
            monYearCard.Text = monYearCard.Text.Remove(3, 2) + monthCbx.SelectedValue.ToString();
        }

        private void tbxCvv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}