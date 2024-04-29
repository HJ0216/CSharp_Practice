using Microsoft.Win32;
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
    /// Interaction logic for WindowTextInfo.xaml
    /// </summary>
    public partial class WindowTextInfo : Window
    {
        public WindowTextInfo()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if(inputId.Text == "")
            {
                MessageBox.Show("The ID is empty!", "Alert");
                return;
            }
            if (inputFirstName.Text == "")
            {
                MessageBox.Show("The First Name is empty!", "Alert");
                return;
            }
            if (inputLastName.Text == "")
            {
                MessageBox.Show("The Last Name is empty!", "Alert");
                return;
            }

            string fileName = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:";
            saveFileDialog.DefaultExt = "txt";

            saveFileDialog.Filter = "Normal Text File|*.txt";

            if(saveFileDialog.ShowDialog() == true)
            {
                fileName = saveFileDialog.FileName.ToString();

                string contents = "ID: " + inputId.Text + "\r\n"
                    + "First Name: " + inputFirstName.Text + "\r\n"
                    + "Last Name: " + inputLastName.Text;

                File.WriteAllText(fileName, contents, Encoding.UTF8);

                // Path to Debug that execution file located.
                //string applicationPath = AppDomain.CurrentDomain.BaseDirectory;

                inputId.Text = string.Empty;
                inputFirstName.Text = string.Empty;
                inputLastName.Text = string.Empty;

                inputId.Focus();
            }

        }
    }
}
