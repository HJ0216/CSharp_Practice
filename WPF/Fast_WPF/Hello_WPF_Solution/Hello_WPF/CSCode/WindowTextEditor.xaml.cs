using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for WindowTextEditor.xaml
    /// </summary>
    public partial class WindowTextEditor : Window
    {
        public WindowTextEditor()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("C:\\Users\\user\\Desktop\\temp.txt", textBox.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            textBox.Text = File.ReadAllText("C:\\Users\\user\\Desktop\\temp.txt");
        }
    }
}
