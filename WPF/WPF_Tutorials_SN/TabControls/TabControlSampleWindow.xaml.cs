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

namespace TabControls
{
    /// <summary>
    /// Interaction logic for TabControlSampleWindow.xaml
    /// </summary>
    public partial class TabControlSampleWindow : Window
    {
        public TabControlSampleWindow()
        {
            InitializeComponent();
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tabControl.SelectedIndex - 1;
            if(newIndex < 0)
            {
                newIndex = tabControl.Items.Count - 1;
            }
            tabControl.SelectedIndex = newIndex;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            int newIndex = tabControl.SelectedIndex + 1;
            if (newIndex >= tabControl.Items.Count)
            {
                newIndex = 0;
            }
            tabControl.SelectedIndex = newIndex;
        }

        private void selectedButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Selected tab: " + (tabControl.SelectedItem as TabItem).Header); 
            // System.Windows.Controls.StackPanel
            MessageBox.Show("Selected tab: " + ((tabControl.SelectedItem as TabItem).Header as StackPanel).Children.OfType<TextBlock>().First().Text);
        }
    }
}
