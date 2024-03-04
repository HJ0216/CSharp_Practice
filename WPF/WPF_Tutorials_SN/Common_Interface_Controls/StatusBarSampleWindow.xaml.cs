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

namespace Common_Interface_Controls
{
    /// <summary>
    /// Interaction logic for StatusBarSampleWindow.xaml
    /// </summary>
    public partial class StatusBarSampleWindow : Window
    {
        public StatusBarSampleWindow()
        {
            InitializeComponent();
        }

        private void textEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = textEditor.GetLineIndexFromCharacterIndex(textEditor.CaretIndex);
            int column = textEditor.CaretIndex - textEditor.GetLineIndexFromCharacterIndex(row);
            cursorPosition.Text = "Line " + (row + 1) + ", Char " + (column + 1) + ", textEditor.CaretIndex" + textEditor.CaretIndex + ", " + textEditor.GetLineIndexFromCharacterIndex(row) + ", textEditor.GetLineIndexFromCharacterIndex(textEditor.CaretIndex)" + textEditor.GetLineIndexFromCharacterIndex(textEditor.CaretIndex);
        }
    }
}
