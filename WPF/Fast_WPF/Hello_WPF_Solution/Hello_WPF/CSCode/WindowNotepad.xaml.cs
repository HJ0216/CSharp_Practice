using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace Hello_WPF.CSCode
{
    /// <summary>
    /// Interaction logic for WindowNotepad.xaml
    /// </summary>
    public partial class WindowNotepad : Window
    {
        public WindowNotepad()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Text = "";
            textBoxControl.Focus();
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text Files|*.txt";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            bool? dialogResult = fileDialog.ShowDialog();

            if (dialogResult == false)
            {
                return;
            }

            textBoxControl.Text = File.ReadAllText(fileDialog.FileName, Encoding.UTF8);

        }

        private void saveAsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text Files|*.txt";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileDialog.AddExtension = true;

            bool? dialogResult = fileDialog.ShowDialog();

            // 실행 취소
            if (dialogResult == false)
            {
                return;
            }

            // SaveFileDialog를 사용할 때, 사용자가 파일 이름을 입력하지 않고 "저장"을 클릭하면
            // 대화 상자는 자동으로 "저장" 버튼을 비활성화시키기 때문에,
            // 사용자가 이름 없이 파일을 저장하는 시나리오는 일반적으로 발생하지 않습니다

            File.WriteAllText(fileDialog.FileName, textBoxControl.Text, Encoding.UTF8);
            MessageBox.Show("Done!");
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Undo();
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Redo();
        }

        private void cutButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Cut();
        }

        private void copyButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Copy();
        }

        private void pasteButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Paste();
        }

        private void selectAllButton_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.Focus();
            textBoxControl.SelectAll();
        }

        private void wordWrapButton_Click(object sender, RoutedEventArgs e)
        {
            if(wordWrapButton.IsChecked == true)
            {
                textBoxControl.TextWrapping = TextWrapping.Wrap;
            }
            else
            {
                textBoxControl.TextWrapping = TextWrapping.NoWrap;
            }
        }

        private void zoonInButton_Click(object sender, RoutedEventArgs e)
        {
            int incrementOfZoom = 4;

            if(textBoxControl.FontSize + incrementOfZoom >= 48)
            {
                textBoxControl.FontSize = 48;
                return;
            }

            textBoxControl.FontSize += incrementOfZoom;
        }

        private void zoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            int decrementOfZoom = 4;

            if (textBoxControl.FontSize - decrementOfZoom <= 8)
            {
                textBoxControl.FontSize = 8;
                return;
            }

            textBoxControl.FontSize -= decrementOfZoom;
        }

        private void defaultZoom_Click(object sender, RoutedEventArgs e)
        {
            textBoxControl.FontSize = 12;
        }

        private void aboutUsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowAboutUs window = new WindowAboutUs();
            window.ShowDialog();
        }
    }
}
