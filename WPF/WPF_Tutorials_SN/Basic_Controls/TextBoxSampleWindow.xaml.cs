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
    /// Interaction logic for TextBoxSampleWindow.xaml
    /// </summary>
    public partial class TextBoxSampleWindow : Window
    {
        public TextBoxSampleWindow()
        {
            InitializeComponent();
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textStatus.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
            textStatus.Text += "Selection is " + textBox.SelectionLength + " character(s) long" + Environment.NewLine;
            textStatus.Text += "Selected text: '" + textBox.SelectedText + "'";
        }
    }
}
