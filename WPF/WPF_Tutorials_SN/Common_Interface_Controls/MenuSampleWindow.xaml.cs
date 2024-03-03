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
    /// Interaction logic for MenuSampleWindow.xaml
    /// </summary>
    public partial class MenuSampleWindow : Window
    {
        public MenuSampleWindow()
        {
            InitializeComponent();
        }

        private void NewCommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            textEditor.Text = "";
        }

    }
}
