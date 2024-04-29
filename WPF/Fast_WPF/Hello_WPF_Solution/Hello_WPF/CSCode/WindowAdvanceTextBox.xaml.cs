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

namespace Hello_WPF.CSCode
{
    /// <summary>
    /// Interaction logic for WindowAdvanceTextBox.xaml
    /// </summary>
    public partial class WindowAdvanceTextBox : Window
    {
        public WindowAdvanceTextBox()
        {
            InitializeComponent();
        }

        private void zoomIn_Click(object sender, RoutedEventArgs e)
        {
            int maxFontSize = 72;
            
            if(mainTextBox.FontSize >= maxFontSize)
            {
                mainTextBox.FontSize = maxFontSize;
                return;
            }

            mainTextBox.FontSize += 2;
        }

        private void zoomOut_Click(object sender, RoutedEventArgs e)
        {
            int minFontSize = 8;

            if (mainTextBox.FontSize <= minFontSize)
            {
                mainTextBox.FontSize = minFontSize;
                return;
            }

            mainTextBox.FontSize -= 2;
        }

        private void selectAll_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Focus();
            mainTextBox.SelectAll();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Undo();
            mainTextBox.UndoLimit = 5;
        }

        private void redo_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Redo();
        }

        private void copy_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Copy();
        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Cut();
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            mainTextBox.Paste();
        }

        bool isWrap = false;

        private void isWrapButton_Click(object sender, RoutedEventArgs e)
        {
            isWrap = !isWrap;
            if(isWrap == true)
            {
                isWrapButton.Content = "Disable Wrap";
                mainTextBox.TextWrapping = TextWrapping.Wrap;
                mainTextBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                return;
            }
            if(isWrap == false)
            {
                isWrapButton.Content = "Enable Wrap";
                mainTextBox.TextWrapping = TextWrapping.NoWrap;
                mainTextBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                return;
            }
        }
    }
}
